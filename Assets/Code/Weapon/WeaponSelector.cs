using UnityEngine;

public sealed class WeaponSelector
{
    private Weapon[] weapons;
    private int currentWeaponIndex=0;
    private Weapon currentWeapon;

    public Weapon CurrentWeapon { get => currentWeapon; }

    public WeaponSelector(Weapon[] weapons)
    {
        this.weapons = weapons;

        foreach (Weapon weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
        
        currentWeapon = weapons[currentWeaponIndex];
        CurrentWeapon.gameObject.SetActive(true);
    }

/// 
    public void Run()
    {
        SelectWeapon();
    }
    private void SelectWeapon()
    {
        MouseWheelSetIndex();
        KeyboardSetIndex();
    }

    private void KeyboardSetIndex()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeaponIndex = 0;
            SwapWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeaponIndex = 1;
            SwapWeapon();
        }
    }

    private void MouseWheelSetIndex()
    {
        float scrollWheel=Input.GetAxis("Mouse ScrollWheel");

        if(scrollWheel>0f)
        {
            if(currentWeaponIndex==weapons.Length-1)
            {
                return;
            }
            else
            {
                currentWeaponIndex++;
                SwapWeapon();
            }
        }
        else if(scrollWheel<0f)
        {
            if(currentWeaponIndex==0)
            {
                return;
            }
            else
            {
                currentWeaponIndex--;
                SwapWeapon();
            }
        }
    }

     private void SwapWeapon()
    {
        currentWeapon.gameObject.SetActive(false);
        currentWeapon = weapons[currentWeaponIndex];
        currentWeapon.gameObject.SetActive(true);

        GameEvents.OnWeaponSwap?.Invoke();
    }
}
