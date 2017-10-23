using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour, IPoolable, ITakeDamage
{
    public float speed, distance;

    public float health;

    public Vector2 myV2Position { get { return new Vector2(transform.position.x, transform.position.y); } }

    public float damage { get { return BulletsManager.Instance.weaponData.damage; } }

    private float levelDepSpeed { get { return MeteorSpawner.Instance.meteorData.speedML; } }
    private float levelDepHealth { get { return MeteorSpawner.Instance.meteorData.healthMl; } }

    public int myValue;

    private Vector2 target;

    void Start ()
    {

	}

    private void OnEnable()
    {
        speed = Random.Range(2, 7) * levelDepSpeed;
        health = Random.Range(2, 6) * levelDepSpeed;
        myValue = Mathf.RoundToInt((speed + health) / 2);
    }

    void SetTargetVector(Vector2 targ)
    {
        target = targ;
    }
	
	void Update ()
    {
        //distance = Vector2.Distance(Vector2.zero, myV2Position);
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position.y >= target.y)
            SetOff();
    }

    public void SetOff()
    {
        gameObject.SetActive(false);
        MeteorSpawner.Instance.ConfigAndPull(gameObject);
        //transform.parent.gameObject.SendMessage("ConfigAndPull", gameObject, SendMessageOptions.DontRequireReceiver);
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            ScoreManager.Instance.CheckPoitns(Mathf.Clamp(myValue, 2, 20));
            SetOff();
        }
    }
}
