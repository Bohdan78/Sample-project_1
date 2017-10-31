using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataManager
{
    Vector2[] SetupPikes(IReasorceItemPooler obj, string signature);
    Sprite SetupView(IReasorceItemPooler obj, string signature);
    float SetupHealth(IReasorceItemPooler obj, string signature);

    string triangleSign { get; }
    string squareSign { get; }
    string hexagonSign { get; }

    float triangleHP { get ; } 
    float squareHP { get ; }
    float pentagonHP { get ; }

    float bulletDmg { get; }
}
