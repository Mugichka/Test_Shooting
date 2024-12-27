using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(WeaponList), menuName = "Data/WeaponList")]
public class WeaponList : ScriptableObject
{
    public List<Weapon> weapons;
}
