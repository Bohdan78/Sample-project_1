using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerController
{
    public KeyCode up = new KeyCode();
    public KeyCode down = new KeyCode();
    public KeyCode left = new KeyCode();
    public KeyCode right = new KeyCode();
    public KeyCode shoot = new KeyCode();

    private bool shootEnabled;
    private float shootTime, shootTimeLimit;

    private IPlayerView myView;

    private IBulletsPool bulletPool;

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
        ScoreManager.OnUpWeapon += UpgradeGun;

        Init();
        shootEnabled = true;
        shootTimeLimit = 0.2f;

        myView = transform.GetChild(0).GetComponent<IPlayerView>();
        bulletPool = GameObject.FindGameObjectWithTag("bulletPool").GetComponent<IBulletsPool>();
    }

    private void Init()
    {
        transform.position = Vector2.zero;
        transform.eulerAngles = Vector2.zero;
        CheckControlls();
        speed = speed <= 0 ? 3 : speed;
    }

    private void CheckControlls()
    {
        up = up == KeyCode.None ? KeyCode.W : up;
        down = down == KeyCode.None ? KeyCode.S : down;
        left = left == KeyCode.None ? KeyCode.A : left;
        right = right == KeyCode.None ? KeyCode.D : right;
        shoot = shoot == KeyCode.None ? KeyCode.Mouse0 : shoot;
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

        if (shootEnabled && Input.GetKeyDown(shoot))
        {
            shootEnabled = false;
            bulletPool.Shoot(this);
            myView.Shoot(this);
        }

        if (!shootEnabled)
            ShootTimer();
    }

    private void ShootTimer()
    {
        shootTime += Time.deltaTime;
        if(shootTime >= shootTimeLimit)
        {
            shootTime = 0;
            shootEnabled = true;
        }

    }

    private void UpgradeGun()
    {
        myView.SwitchGun(this);
        shootTimeLimit *= 0.5f;
    }

    public void EnableShoot(IPlayerView obj)
    {
        shootEnabled = true;
    }

    private void MovingUpDown(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }

    private void MovingLeftRight(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }

    //public void TakeDamage(float damage)
    //{
    //    playerHealth -= damage;
    //    if (playerHealth <= 0)
    //        GameController.Instance.EndGame(this);
    //}
}
