using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public Transform myTransform;
    private Vector2 target;

    private GameObject bulletPool;

    private int damageLevel;
    private float pullSpeed;

    private BoxCollider2D myCollider;

    private void Awake()
    {
        myTransform = transform;
    }

    void Start ()
    {
        target = new Vector2(7.5f, PlayerController.Instance.getY_Position);
        damageLevel = 1;
        pullSpeed = 10;

        bulletPool = GameObject.FindGameObjectWithTag("bulletPool");
        transform.parent = null;

        myCollider = gameObject.GetComponent<BoxCollider2D>();
        myCollider.isTrigger = false;
    }

    public void ReInvoke()
    {
        myTransform.parent = null;
        target = new Vector2(7.5f, PlayerController.Instance.getY_Position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Coll");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Coll2");
    }

    void Update ()
    {
        // myTransform.Translate(target);
        myTransform.localPosition = Vector2.MoveTowards(myTransform.localPosition, target, Time.deltaTime * pullSpeed);
        if (myTransform.localPosition.x >= 7.5f)
            ReturnToPool();
	}

    private void ReturnToPool()
    {
        transform.parent = bulletPool.transform;
        myTransform.localPosition = Vector2.zero;
        gameObject.SetActive(false);
        damageLevel = 1;
    }
}
