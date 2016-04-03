using UnityEngine;
using System.Collections;

public class Weapon {

    public string weaponName { get; set; }
    public int weaponAttackDamage { get; set; }

    public Weapon(string weaponName, int weaponAttackDamage)
    {
        this.weaponName = weaponName;
        this.weaponAttackDamage = weaponAttackDamage;
    }
}
