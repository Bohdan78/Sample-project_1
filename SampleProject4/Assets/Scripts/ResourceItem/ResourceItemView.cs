using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceItemView : MonoBehaviour, IResourceView
{

    private IResourceItem itemManager;

    void Start()
    {
       itemManager = transform.parent.GetComponent<IResourceItem>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "bullet")
        {
            IBullet bullet = target.GetComponentInParent<IBullet>();
            bullet.SetOff();
            itemManager.DealDamage(this, bullet.DealDamage());
        }
    }
}
