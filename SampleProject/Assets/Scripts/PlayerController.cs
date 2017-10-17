using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public static PlayerController Instance { set; get; }
    
    private Transform myTransform;

    public float getY_Position {  get { return myTransform.position.y; } }

    [SerializeField]
    private float moveSpeed, controllSpeed, additionalSpeed;

    public float getAdditionalSpeed { get { return additionalSpeed; } }

    private Vector2 finishTarget, topTarget, bottomTarget;

    [HideInInspector]
    public bool up, down, accelerate, brake, shoot;

    

    private void Awake()
    {
        Instance = this;
    }

    void Start ()
    {
        additionalSpeed = 1f;
        myTransform = transform;
        LevelManager.OnDeath += Death;
        LevelManager.OnRetrieve += Retrieve;
        //moveSpeed = 1f;
        //controllSpeed = 1f;
    }

    private void Retrieve()
    {
        this.enabled = true;
    }
	
    private void Death()
    {
        myTransform.position = new Vector3(-6, 0, 0);
        this.enabled = false;
    }
	
	void Update ()
    {
        //MoveToLeft();

        if(up || Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
        }
        else if(down || Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown();
        }

        if(accelerate || Input.GetKey(KeyCode.RightArrow))
        {
            //Time.timeScale
            ChangeAdditionalSpeed(2.5f);
        }
        else if(brake || Input.GetKey(KeyCode.LeftArrow))
        {
            ChangeAdditionalSpeed(0.1f); 
        }

        else if(additionalSpeed != 1f)
        {
            ChangeAdditionalSpeed(1f);
        }

        if(shoot || Input.GetKeyDown(KeyCode.Space))
        {
            ShootController.Instance.SpawnBulleto();
        }

    }



    //private void MoveToLeft()
    //{
    //    finishTarget = new Vector2(-99999f, myTransform.position.y);
    //    myTransform.position = Vector2.MoveTowards(myTransform.position, finishTarget, Time.deltaTime * moveSpeed * additionalSpeed);
    //}

    private void ChangeAdditionalSpeed(float target)
    {
        additionalSpeed = Mathf.MoveTowards(additionalSpeed, target, Time.deltaTime * 2);
    }
   
    private void MoveUp()
    {
        topTarget = new Vector2(myTransform.position.x, 4.5f);
        myTransform.position = Vector2.MoveTowards(myTransform.position, topTarget, Time.deltaTime * controllSpeed * additionalSpeed);
    }

    private void MoveDown()
    {
        bottomTarget = new Vector2(myTransform.position.x, -4.5f);
        myTransform.position = Vector2.MoveTowards(myTransform.position, bottomTarget, Time.deltaTime * controllSpeed * additionalSpeed);
    }

    
}
