using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataManager : MonoBehaviour, IMeteorData, IWeaponData, IScoreData
{
    public int amount { get { return mData.totalAmount; } }
    public float healthMl { get { return mData.healthMultiplier; } }
    public float speedML { get { return mData.speedMultiplier; }  }

    public int pointsToUpgrade { get { return wData.pointsToUpgrade; } }
    public int damage { get { return wData.bulletDamage; } }
    public Color bulletColor { get { return wData.CurrentColor(BulletsManager.Instance.getBulletLevel); } }

    public int scoreLimit { get { return sData.PointsToNextLevel(GameController.Instance.currentLevel); } }

    public MeteorData mData;
    public WeaponData wData;
    public ScoreData sData;

    void Start ()
    {
        ReInit();
        GameController.OnStart += ReInit;
    }

    private void ReInit()
    {
        mData.DefaultValues();
        wData.DefaultValues();
    }
}
