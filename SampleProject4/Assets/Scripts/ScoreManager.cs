using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IScoreManager {

    public delegate void UpWeapon();
    public static event UpWeapon OnUpWeapon;

    private int score, levelLimScore;
    public int scoreValue { get { return score; } }

    private int level;
    public int levelValue { get { return level; } }

    private IUIController uiController;

    private enum WeaponLevel: int { TANK, BULLETSHTORMERR}
    private WeaponLevel weaponLevel;

	void Start ()
    {
        score = 0;
        uiController = GameObject.FindGameObjectWithTag("UI").GetComponent<IUIController>();
        LevelPlus(score);
    }

    public void ScorePlus(IReasorceItemPooler obj, int value)
    {
        score += value;
        uiController.SetPoints(this, score);

        if (score > levelLimScore)
            LevelPlus(score);
    }

    private void LevelPlus(int pts)
    {
        level += 1;
        levelLimScore = (level * 9 - 4) * (level + 2) ;
        if (pts > levelLimScore)
            LevelPlus(pts);
        else if (pts <= levelLimScore)
            uiController.SetLevel(this, level);

        if(level>= 8 && weaponLevel == WeaponLevel.TANK)
        {
            weaponLevel = WeaponLevel.BULLETSHTORMERR;
            OnUpWeapon();
        }
    }




}
