
// State of actor in combat
public enum ActorState
{
    NORMAL,
    DEFENDING
}

// Don't fucking initialise this pls
public abstract class Actor {

    protected int actorLevel;

    protected Stats maxStats, currentStats;

    protected Weapon weapon;

    protected ActorState actorState;

    protected string actorName { get; set; }

    // First time initialisation
    public Actor(Stats maxStats, Weapon weapon, string actorName, int actorLevel)
    {
        this.actorLevel = actorLevel;
        this.weapon = weapon;
        this.actorName = actorName;
        this.actorState = ActorState.NORMAL;
        this.maxStats = maxStats;
        this.currentStats = maxStats;
    }

    // For ze loading cuz we dont know how serialization is going te work
    public Actor(Stats maxStats, Stats currentStats, Weapon weapon, string actorName, int actorLevel)
    {
        this.actorLevel = actorLevel;
        this.weapon = weapon;
        this.actorName = actorName;
        this.actorState = ActorState.NORMAL;
        this.maxStats = maxStats;
        this.currentStats = currentStats;
    }

    // Common functions across actors in combat
    protected int GetActorAttackDamage() { return maxStats.strengthPoints + weapon.weaponAttackDamage; }

    protected Stats getMaxStats() { return maxStats; }

    protected Stats getCurrentStats() { return currentStats; }

    
}

