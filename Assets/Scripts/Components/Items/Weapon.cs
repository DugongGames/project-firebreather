using UnityEngine;
using System.Collections;

public class Weapon {

    string weaponName { get; set; }
    int weaponAttackDamage { get; set; }

    public Weapon(string weaponName, int weaponAttackDamage)
    {
        this.weaponName = weaponName;
        this.weaponAttackDamage = weaponAttackDamage;
    }
}
