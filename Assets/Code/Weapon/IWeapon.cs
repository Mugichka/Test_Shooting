using System;
using System.Threading;
using Cysharp.Threading.Tasks;


public interface IWeapon
{
    void Shoot();
    UniTask Reload(CancellationToken token);
    bool CanShoot { get; }
    int CurrentAmmo { get; }
    int MaxAmmo { get; }
}
