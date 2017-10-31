using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthBar
{
    void SetDamage(float health);

    void ResetBarView();
}
