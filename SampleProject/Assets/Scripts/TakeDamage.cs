using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    private ObstacleController myController;
    private ObstacleType myType;
    
    void Start ()
    {
        myController = transform.parent.GetComponent<ObstacleController>();
        myType = transform.parent.GetComponent<ObstacleType>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        print("OnEnter");
        if (target.tag == "bullet")
        {
            target.SendMessage("ReturnToPool", null, SendMessageOptions.DontRequireReceiver);
            Damage(myType.getDamageValue);
        }
        else if (target.tag == "player")
            LevelManager.Instance.EndGame();
    }


    public void Damage(int dmg)
    {
        //print("DMG!");
        myController.CountDamage(dmg);
    }
}
