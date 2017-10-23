using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IPoolable
{
    private SpriteRenderer myViewRend;

    public float speed, distance;

    public Vector2 myV2Position { get { return new Vector2(transform.position.x, transform.position.y); } }

    private Transform bulletPool;

    private void Start ()
    {
        bulletPool = GameObject.FindGameObjectWithTag("BulletPool").transform;
        myViewRend = transform.GetChild(0).GetComponent<SpriteRenderer>();
        myViewRend.color = BulletsManager.Instance.weaponData.bulletColor;
        BulletsManager.OnUpBullet += ChangeColor;
    }

    public void ChangeColor()
    {
        myViewRend.color = BulletsManager.Instance.weaponData.bulletColor;
    }

    private void OnEnable()
    {
        transform.parent = null;
    }

    private void Update ()
    {
        distance = Vector2.Distance(Vector2.zero, myV2Position);

        if (distance >= 11)
            SetOff();

        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    public void SetOff()
    {
        transform.parent = bulletPool;
        transform.localEulerAngles = Vector3.zero;
        gameObject.SetActive(false);
        transform.localPosition = Vector2.zero;
        distance = 0;
    }
    
}
