using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IBullet
{
   

    private SpriteRenderer myViewRend;

    public float speed, distance;

    public Vector2 myV2Position { get { return new Vector2(transform.position.x, transform.position.y); } }

    private Transform bulletPool;
    private IBulletsPool bulletData;

    private float timer = 0f;

    private float lifetime;

    Vector3 offset = Vector3.zero;

    private bool offsetEnabled;

    private void Start ()
    {
        ScoreManager.OnUpWeapon += BulletOffset;

        lifetime = 2f;
        bulletPool = GameObject.FindGameObjectWithTag("bulletPool").transform;
        bulletData = bulletPool.GetComponent<IBulletsPool>();

        //myViewRend = transform.GetChild(0).GetComponent<SpriteRenderer>();
        //myViewRend.color = BulletsManager.Instance.weaponData.bulletColor;
        //BulletsManager.OnUpBullet += ChangeColor;
    }

    private void BulletOffset()
    {
        offsetEnabled = true;
    }

    private void OnEnable()
    {
        transform.parent = null;
        if (offsetEnabled)
        {
            offset = new Vector3(0, 0, Random.Range(-15f, 15f));
            transform.eulerAngles += offset;
        }
        
    }

    private void Update ()
    {
        timer += Time.deltaTime;
        if(timer >= lifetime)
            SetOff();

        transform.Translate(Vector3.right  * Time.deltaTime * speed);
    }

    public void SetOff()
    {
        transform.parent = bulletPool;
        transform.localEulerAngles = Vector3.zero;
        gameObject.SetActive(false);
        transform.localPosition = Vector2.zero;
        timer = 0;
    }

    public float DealDamage()
    {
        return bulletData.damageValue;
    }
    
}
