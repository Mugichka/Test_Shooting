using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;
using TMPro;
using System.Linq;

public sealed class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;

    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TextMeshProUGUI reloadText;


    private Weapon currentWeapon;
    private CancellationTokenSource reloadCts;
    private int currentWeaponIndex=0;

    private void OnEnable()
    {
        GameEvents.OnShoot += UpdateUI;
        GameEvents.OnReloadFinish += UpdateUI;
        GameEvents.OnWeaponLoaded += UpdateUI;
    }

    void OnDisable()
    {
        GameEvents.OnShoot -= UpdateUI;
        GameEvents.OnReloadFinish -= UpdateUI;
        GameEvents.OnWeaponLoaded -= UpdateUI;
    }

    void Start()
    {
         foreach (Weapon weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
        currentWeapon = weapons[0];
        currentWeapon.gameObject.SetActive(true);

        UpdateUI();
    }

    void Awake()
    {
       
    }

    void Update()
    {
        MouseWheelSwapWeapon();
        
        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //UpdateUI();
            reloadCts?.Cancel();
            reloadCts = new CancellationTokenSource();
            currentWeapon.Reload(reloadCts.Token).Forget();
            UpdateUI();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapWeapon(0);
            currentWeaponIndex=0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapWeapon(1);
            currentWeaponIndex=1;
        }

    }

    private void SwapWeapon(int newWeaponIndex)
    {
        currentWeapon.gameObject.SetActive(false);
        currentWeapon = weapons[newWeaponIndex];
        currentWeapon.gameObject.SetActive(true);

        UpdateUI();
    }

    private void UpdateUI()
    {
        ammoText.text = currentWeapon.CurrentAmmo + " / " + currentWeapon.MaxAmmo;
        reloadText.text = currentWeapon.IsReloading ? "Reloading..." : "";
    }

    private void MouseWheelSwapWeapon()
    {
        if(Input.GetAxis("Mouse ScrollWheel")>0f)
        {
            if(currentWeaponIndex==weapons.Count()-1)
            {
                return;
            }
            else
            {
                currentWeaponIndex++;
                SwapWeapon(currentWeaponIndex);
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel")<0f)
        {
            if(currentWeaponIndex==0)
            {
                return;
            }
            else
            {
                currentWeaponIndex--;
                SwapWeapon(currentWeaponIndex);
            }
        }
    }
}
