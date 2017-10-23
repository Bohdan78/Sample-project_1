using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorView : MonoBehaviour {

    private SpriteRenderer myRend;

    private ITakeDamage meteorDamage, playerDamage;

    void Start ()
    {
        myRend = gameObject.GetComponent<SpriteRenderer>();
        meteorDamage = transform.parent.GetComponent<ITakeDamage>();
        playerDamage = GameObject.FindGameObjectWithTag("Player").transform.parent.GetComponent<ITakeDamage>();
    }
	
	private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bullet")
        {
            meteorDamage.TakeDamage(meteorDamage.damage);
            target.GetComponentInParent<IPoolable>().SetOff();
        }
        else if (target.tag == "Player")
        {
            playerDamage.TakeDamage(playerDamage.damage);
        }
    }
}
