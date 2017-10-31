using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour, IBulletsPool
{
    public delegate void BulletLevel();
    public static event BulletLevel OnUpBullet;

    [SerializeField]
    private List<GameObject> bullets;
    public int bulletsLenth;

    private int bulletLevel;
    public int getBulletLevel { get {return bulletLevel - 1;} } 

    public float damageValue {  get { return dataManager.bulletDmg; } }

    private IDataManager dataManager;

    private static BulletsPool Instance { set; get; } //closed singleton

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;

        foreach (Transform child in transform)
            bullets.Add(child.gameObject);
    }

    void Start()
    {
        dataManager = GameObject.FindGameObjectWithTag("dataManager").GetComponent<IDataManager>();
        bulletsLenth = bullets.Count;
        bulletLevel = 1;
    }

    private void ReInit()
    {
        bulletLevel = 1;
        OnUpBullet();
    }

    public void Shoot(IPlayerController obj)
    {
        try
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        catch (UnityException ex)
        {
            //if(ex.Message == "Transform child out of bounds")
            Debug.Log(ex.Message);
            return;
        }
    }
}
