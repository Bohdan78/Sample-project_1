using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
    public delegate void BulletLevel();
    public static event BulletLevel OnUpBullet;

    [SerializeField]
    private List<GameObject> bullets;
    public int bulletsLenth;

    private int bulletLevel;
    public int getBulletLevel { get {return bulletLevel - 1;} } 

    public IWeaponData weaponData;

    private DataManager dataManager;

    public static BulletsManager Instance { set; get; }

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
        weaponData = GameObject.FindGameObjectWithTag("Controller").GetComponent<IWeaponData>();
        dataManager = GameObject.FindGameObjectWithTag("Controller").GetComponent<DataManager>();
        bulletsLenth = bullets.Count;
        bulletLevel = 1;
        GameController.OnStart += ReInit;
    }

    private void ReInit()
    {
        bulletLevel = 1;
        OnUpBullet();
    }

    public void WeaponLevelUp(ScoreManager obj)
    {
        bulletLevel += 1;
        dataManager.wData.UpValues();
        OnUpBullet();
    }

    public void Shoot()
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
