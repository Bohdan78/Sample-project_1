using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreManager
{
    int scoreValue { get; }

    int levelValue{ get; }

    void ScorePlus(IReasorceItemPooler obj, int value);
}
