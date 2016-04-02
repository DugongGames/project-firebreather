using UnityEngine;
using System.Collections;

public class Actor {

    Stats maxStats;
    Stats currentStats;

    //First time initialisation
    public Actor(Stats maxStats)
    {
        this.maxStats = maxStats;
        this.currentStats = maxStats;
    }

    //For ze loading
    public Actor(Stats maxStats, Stats currentStats)
    {
        this.maxStats = maxStats;
        this.currentStats = currentStats;
    }


}
