using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResourceItem
{
    float healthPoints { get; }

    void DealDamage(IResourceView obj, float damage);

    void InitReasorce(IReasorceItemPooler obj, string signature, Vector2[] pikes, Sprite view, float health);



}
