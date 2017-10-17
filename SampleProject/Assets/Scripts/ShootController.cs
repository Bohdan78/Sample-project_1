using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

    [SerializeField]
    private List<GameObject> bullets;
    [SerializeField]
    private List<BulletController> bulletsCtrl;
    private int bulletsLenth;

    public static ShootController Instance { set; get; }

    

    private void Awake()
    {
        Instance = this;
        
    }

    void Start ()
    {
        bulletsLenth = bullets.Count;
        for (int i = 0; i < bulletsLenth; i++)
        {
            bulletsCtrl.Add(bullets[i].GetComponent<BulletController>());
        }
    }
	
	

    public void SpawnBulleto()
    {
        for(int c = 0; c < bulletsLenth; c++)
        {
            if(!bullets[c].activeInHierarchy)
            {
                bullets[c].SetActive(true);
                bulletsCtrl[c].ReInvoke();
                //bullets[c].SendMessage("ReInvoke", null, SendMessageOptions.DontRequireReceiver);
                return;
            }
        }
    }
}
