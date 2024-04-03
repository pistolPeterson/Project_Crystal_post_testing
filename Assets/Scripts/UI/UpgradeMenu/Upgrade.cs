using UnityEngine;

[System.Serializable]
public class Upgrade
{
    public enum UpgradeType
    {
        BasicDamagePercent,
        PierceDamagePercent,
        MaxManaPercent,
        MaxHealthPercent,
        AbilityCooldownPercent,
    }

    public UpgradeType upgradeType;
    public float upgradeValue;

    public string GetUpgradeDescription()
    {
        switch (upgradeType)
        {
            case UpgradeType.BasicDamagePercent:
                return "Increase Basic Attack (M1) Damage by " + (int)(upgradeValue * 100) + "%";
            case UpgradeType.PierceDamagePercent:
                return "Increase Pierce Attack (Q) Damage by " + (int)(upgradeValue * 100) + "%";
            case UpgradeType.MaxManaPercent:
                return "Increase Max Mana by " + (int)(upgradeValue * 100) + "%";
            case UpgradeType.MaxHealthPercent:
                return "Increase Max Health by " + (int)(upgradeValue * 100) + "%";
            case UpgradeType.AbilityCooldownPercent:
                return "Decrease All Ability Cooldowns by " + (int)(upgradeValue * 100) + "%";
            default:
                return "Unknown";
        }
    }

    public void ApplyUpgrade()
    {
        switch (upgradeType)
        {
            case UpgradeType.BasicDamagePercent:
                BuffManager.instance.IncreaseMaxBasicAttackDamage(upgradeValue);
                break;
            case UpgradeType.PierceDamagePercent:
                BuffManager.instance.IncreaseMaxPierceShotDamage(upgradeValue);
                break;
            case UpgradeType.MaxManaPercent:
                BuffManager.instance.IncreaseMaxMana(upgradeValue);
                BuffManager.instance.AddMana(Mathf.RoundToInt(upgradeValue * 100));
                break;
            case UpgradeType.MaxHealthPercent:
                BuffManager.instance.IncreaseMaxHealth(upgradeValue);
                BuffManager.instance.AddHealth(Mathf.RoundToInt(upgradeValue * 100));
                break;
            case UpgradeType.AbilityCooldownPercent:
                BuffManager.instance.ReduceAllAbilityCooldowns(upgradeValue);
                break;
        }
    }
}