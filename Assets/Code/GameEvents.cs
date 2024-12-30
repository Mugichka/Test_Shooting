using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents 
{
    public static Action OnShoot;
    public static Action OnReloadFinish;
    public static Action OnReloadStart;
    public static Action OnReloadStop;
    public static Action OnWeaponLoaded;
    public static Action OnWeaponSwap;

    public static Action OnPlayerMove;
    public static Action OnPlayerStopMove;
    public static Action OnPlayerJump;
    public static Action OnPlayerLand;
}
