using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletsPool
{
    void Shoot(IPlayerController obj);

    float damageValue { get; }
}
