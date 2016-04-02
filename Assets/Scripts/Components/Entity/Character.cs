
public class Character : Actor {

    public Character(Stats maxStats, string characterName, Weapon weapon, int characterLevel) :
        base(maxStats, weapon, characterName, characterLevel)
    {

    }

    public Character(Stats maxStats, Stats currentStats, Weapon weapon, string characterName, int characterLevel) :
        base(maxStats, currentStats, weapon, characterName, characterLevel)
    {

    }

    


}