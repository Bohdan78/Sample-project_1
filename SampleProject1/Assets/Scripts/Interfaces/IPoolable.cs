using UnityEngine;

public interface IPoolable
{
    void SetOff();
    
    Vector2 myV2Position { get; }
}
