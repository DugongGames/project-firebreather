using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    public enum BattleState
    {
        //TODO: We will need some enums for player/enemy animations later

        // State value when battle is not commencing
        BATTLE_INACTIVE,
        // State value for battle transistion
        BATTLE_ACTIVE,
        // State value for player's turn
        PLAYER_SELECT,
        // State value for Enemy's turn
        ENEMY_SELECT,
        // State value when all Player's party members are dead
        GAME_OVER,
        // State value when all Enemies are dead
        BATTLE_OVER
    }

    private BattleState battleManagerState;
            
    // Use this for initialization
    void Start()
    {
        //Set state value of Battle
        battleManagerState = BattleState.BATTLE_INACTIVE;

        // Start is only called once per lifecyle
        // We need to use an "init" to call each time we wish
        // to invoke a new instance of a battle
        // init();
    }

    public void init ()
    {
        // We are probs going to call some transitional menu/scene crap with this
        battleManagerState = BattleState.BATTLE_ACTIVE;
    }

    // Update is called once per frame
    void Update()
    {
        if (battleManagerState.Equals(BattleState.BATTLE_ACTIVE))
        {
            MonitorBattleState();
        }
        else
        {
           // Do nout
        }
    }

    // State Monitor for le battles
    private void MonitorBattleState()
    {
        switch (battleManagerState)
        {
            case BattleState.BATTLE_INACTIVE:
                Debug.Log(battleManagerState);
                break;
            case BattleState.BATTLE_ACTIVE:
                Debug.Log(battleManagerState);
                break;
            case BattleState.PLAYER_SELECT:
                Debug.Log(battleManagerState);
                break;
            case BattleState.ENEMY_SELECT:
                Debug.Log(battleManagerState);
                break;
            case BattleState.BATTLE_OVER:
                Debug.Log(battleManagerState);
                break;
            case BattleState.GAME_OVER:
                Debug.Log(battleManagerState);
                break;
        }
    }
}
