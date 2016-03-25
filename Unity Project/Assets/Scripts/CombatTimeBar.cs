using UnityEngine;
using System.Collections;

public class CombatTimeBar : MonoBehaviour {

    public Vector2 bar_size = new Vector2(400, 50);
    public Texture2D bar, icon;
    public float icon_pos = 0;
    public GUIStyle bar_style, icon_style;
    float timer = 0;

    public enum State
    {
        Wait,
        Command,
        Act
    }

    private State _state;
    
    public State state
    {
        get
        {
            return _state;
        }
        set
        {
            _state = value;
        }
    }
    //int ryu_speed = 3;
    //int welp_speed = 2;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (state == State.Wait || state == State.Act)
        {
            timer += Time.deltaTime;

            icon_pos = timer * 0.06f;
        }

        if ( state == State.Wait && icon_pos >= 0.75f)
        {
            state = State.Command;
        }

        if (icon_pos >= 1)
        {
            state = State.Wait;
            icon_pos = 0;
            timer = 0;
        }
	}

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width - bar_size.x,Screen.height - bar_size.y, bar_size.x, bar_size.y));
        GUI.Box(new Rect(0,0,bar_size.x,bar_size.y),bar,bar_style);

            GUI.BeginGroup(new Rect(bar_size.x *icon_pos,0,bar_size.x,bar_size.y));
            GUI.Box(new Rect(0,0,bar_size.x,bar_size.y), icon, icon_style);

            GUI.EndGroup();

        GUI.EndGroup();

        if (state == State.Command)
        {
            if (GUI.Button(new Rect(100, 100, 100, 50), "Command"))
            {
                state = State.Act;
            }
        }
    
    }
}
