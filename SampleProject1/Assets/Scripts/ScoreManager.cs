using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int points;
    private int weaponPoints;

    private IScoreData scoreData;

    private IWeaponData weaponData;

    public static ScoreManager Instance { set; get; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;
    }

    void Start ()
    {
        scoreData = GameObject.FindGameObjectWithTag("Controller").GetComponent<IScoreData>();
        weaponData = GameObject.FindGameObjectWithTag("Controller").GetComponent<IWeaponData>();
        GameController.OnGameOver += Init;
    }

    private void Init()
    {
        points = 0;
        weaponPoints = 0;
    }

    public void CheckPoitns(int pts)
    {
        points += pts;
        weaponPoints += pts;
        UIController.Instance.DisplayPoints(points);

        if (weaponPoints >= weaponData.pointsToUpgrade)
        {
            weaponPoints = 0;
            BulletsManager.Instance.WeaponLevelUp(this);
        }

        if(points >= scoreData.scoreLimit)
        {
            GameController.Instance.LevelUp(this);
            points = 0;
        }
    }
	
	
}
