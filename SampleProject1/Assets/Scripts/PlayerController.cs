using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour , ITakeDamage
{
    public KeyCode up = new KeyCode();
    public KeyCode down = new KeyCode();
    public KeyCode left = new KeyCode();
    public KeyCode right = new KeyCode();
    public KeyCode shoot = new KeyCode();

    [SerializeField]
    private float speed;

    [SerializeField]
    private float maxY, maxX;

    private Vector2 velocity = Vector2.zero, differ;

    [SerializeField]
    private Vector2 mousePosition;

    private Vector2 myV2Position { get { return new Vector2(transform.position.x, transform.position.y); } }

    private float playerHealth = 10;
    public float damage{ get { return playerHealth; } }

    private void Start ()
    {
        Init();
        GameController.OnGameOver += ReInit;
        GameController.OnStart += ReInit;
    }

    private void Init()
    {
        transform.position = Vector2.zero;
        transform.eulerAngles = Vector2.zero;
        CheckControlls();
        speed = speed <= 0 ? 3 : speed;
    }

    private void ReInit()
    {
        Init();
        enabled = !enabled;
    }

    private void CheckControlls()
    {
        up = up == KeyCode.None ? KeyCode.UpArrow : up;
        down = down == KeyCode.None ? KeyCode.DownArrow : down;
        left = left == KeyCode.None ? KeyCode.LeftArrow : left;
        right = right == KeyCode.None ? KeyCode.RightArrow : right;
        shoot = shoot == KeyCode.None ? KeyCode.Space : shoot;
    }
	
	void Update ()
    {

        InputReader();
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = mousePosition - myV2Position;
        //differ = mousePosition - myV2Position;
        //differ.Normalize();
        //transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(differ.x, differ.y) * Mathf.Rad2Deg);
    }

    private void InputReader()
    {
        if (Input.GetKey(up))
        {
            MovingUpDown(new Vector2(transform.position.x, maxY));
        }
        else if (Input.GetKey(down))
        {
            MovingUpDown(new Vector2(transform.position.x, -maxY));
        }

        if (Input.GetKey(left))
        {
            MovingLeftRight(new Vector2(-maxX, transform.position.y));
        }
        else if (Input.GetKey(right))
        {
            MovingLeftRight(new Vector2(maxX, transform.position.y));
        }

        if (Input.GetKeyDown(shoot))
        {
            BulletsManager.Instance.Shoot();
        }
    }

    private void MovingUpDown(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }

    private void MovingLeftRight(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
            GameController.Instance.EndGame(this);
    }
}
