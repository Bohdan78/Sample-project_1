using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon Data", menuName = "Data/Weapon data")]
public class WeaponData : ScriptableObject
{
    [SerializeField]
    private int ptsToUpgrade; 
    [SerializeField]
    private int dmg;
    [SerializeField]
    private List<Color> bulletColors;

    public int pointsToUpgrade {  get { return ptsToUpgrade; } }
    public int bulletDamage { get { return dmg; } }

    public void DefaultValues()
    {
        ptsToUpgrade = 40;
        dmg = 2;
    }

    public void UpValues()
    {
        ptsToUpgrade += ptsToUpgrade / 2;
        dmg += 2;
    }

    public Color CurrentColor(int level)
    {
        return bulletColors[level];
    }
}
