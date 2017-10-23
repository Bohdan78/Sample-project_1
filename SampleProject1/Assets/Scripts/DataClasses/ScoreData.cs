using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score Data", menuName = "Data/Score data")]
public class ScoreData : ScriptableObject
{
    [SerializeField]
    private List<int> ptsLimit;

    public int PointsToNextLevel(int level)
    {
        return ptsLimit[level];
    }
}
