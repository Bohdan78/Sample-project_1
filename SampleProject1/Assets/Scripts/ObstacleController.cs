using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    private GameObject myView;

    private Transform myTransform;

    private Vector2 startPosition;

    private Vector2 finishTarget;

    [SerializeField]
    private int moveSpeed;

    private float additionalSpeed;

    private int armor;
    public int getArmorStats { get { return armor; } }

    public enum armorLevel : int { WEAK, MEDIUM, STRONG };

    void Start ()
    {
        //armor = Random.Range(0, 2);
        myTransform = transform;
        myView = myTransform.GetChild(0).gameObject;
        additionalSpeed = 1;
        startPosition = myTransform.position;
        //Init();
    }

    void Init()
    {

        //startPosition = new Vector2(8.2f, Random.Range(-4, 5));
        myTransform.position = startPosition;
        armor = Rectifier(Random.Range(0, 6));
        myView.SendMessage("SetColor", armor, SendMessageOptions.DontRequireReceiver);
        moveSpeed = Random.Range(2, 7);
    }

    private int Rectifier(int value)
    {
        if (value >= 5)
            value = 2;
        else if (value >= 3)
            value = 1;
        else
            value = 0;
        return value;
    }


    void Update ()
    {
        MoveToLeft();

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            additionalSpeed = PlayerController.Instance.getAdditionalSpeed;
        else if(additionalSpeed != 1f)
            additionalSpeed = PlayerController.Instance.getAdditionalSpeed;

    }

    private void MoveToLeft()
    {
        finishTarget = new Vector2(-8.2f, myTransform.position.y);
        myTransform.position = Vector2.MoveTowards(myTransform.position, finishTarget, Time.deltaTime * moveSpeed * additionalSpeed);
        if (myTransform.position.x <= -8.2f)
            Init();
    }

    public void CountDamage(int damage)
    {
        if(armor > (int)armorLevel.WEAK)
        {
            armor -= 1;
            myView.SendMessage("SetColor", armor, SendMessageOptions.DontRequireReceiver);
        }
        else if(armor <= (int)armorLevel.WEAK)
        {
            Destr();
        }
    }

    public void Destr()
    {
        Init();
        // + some particle system call for...BOOOOM!!!
    }

    public void Restore()
    {
       
    }

}
