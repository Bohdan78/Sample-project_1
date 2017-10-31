using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerView
{
    void SwitchGun(IPlayerController obj);

    void Shoot(IPlayerController obj);
}
