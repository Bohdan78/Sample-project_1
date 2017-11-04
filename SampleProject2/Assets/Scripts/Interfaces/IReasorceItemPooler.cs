using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReasorceItemPooler
{
    void InitResource(IResourceItem obj);

    void SendScore(IResourceItem obj, int pts);

}
