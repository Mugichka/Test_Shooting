using TMPro;

public sealed class WeaponUI
{
    private TextMeshProUGUI ammoText;
    private TextMeshProUGUI reloadText;

    public WeaponUI(TextMeshProUGUI ammoText, TextMeshProUGUI reloadText)
    {
        this.ammoText = ammoText;
        this.reloadText = reloadText;
    }

    public void UpdateUI(string currentAmmo, string maxAmmo, bool isReloading)
    {
        ammoText.text = currentAmmo + " / " + maxAmmo;
        reloadText.text = isReloading ? "Reloading..." : "";
    }
}
