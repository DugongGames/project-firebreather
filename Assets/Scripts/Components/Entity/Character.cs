
public class Character : Actor {

    // First time initialisation
    public Character(Stats maxStats, string characterName, Weapon weapon, int characterLevel) :
        base(maxStats, weapon, characterName, characterLevel)
    {

    }

    // For ze loading cuz we dont know how serialization is going te work
    public Character(Stats maxStats, Stats currentStats, Weapon weapon, string characterName, int characterLevel) :
        base(maxStats, currentStats, weapon, characterName, characterLevel)
    {

    }

}