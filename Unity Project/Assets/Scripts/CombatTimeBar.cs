using UnityEngine;
using System.Collections;

public class CombatTimeBar : MonoBehaviour {

    public Vector2 size = new Vector2(400, 50);
    public Texture2D bar, ryu_icon, welp_icon;
    public float ryu_pos = 0, welp_pos = 0;
    public GUIStyle barStyle, ryuStyle, welpStyle;

    //int ryu_speed = 3;
    //int welp_speed = 2;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        ryu_pos = Time.time * 0.05f;
        welp_pos = Time.time * 0.05f;
	}

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width - size.x,Screen.height - size.y, size.x, size.y));
        GUI.Box(new Rect(0,0,size.x,size.y),bar,barStyle);

            GUI.BeginGroup(new Rect(size.x *ryu_pos,0,size.x,size.y));
            GUI.Box(new Rect(0,0,size.x,size.y), ryu_icon, ryuStyle);

            GUI.EndGroup();

            GUI.BeginGroup(new Rect(size.x * welp_pos, 0, size.x, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), welp_icon, welpStyle);

            GUI.EndGroup();

        GUI.EndGroup();

        
        
        
    }
}
