using UnityEngine;
using System.Collections;

public class MenuSystem : MonoBehaviour
{
    public bool isPaused = false;

    enum State
    {
        Show,
        Hide,
    }

    public GUISkin skin;

    string scene = "start";
    State state;

    void Start()
    {
        state = State.Hide;
    }

    int screenX = Screen.width;
    int screenY = Screen.height;

    void OnGUI()
    {

        GUI.skin = skin;

        //GUILayout.BeginArea(new Rect(50, 50, 250, 250));
        GUILayout.BeginArea(new Rect(screenX - 250, 50, 250, 250));

        if (state == State.Show)
        {
            if (scene == "start")
            {
                GUILayout.BeginVertical();

                if (GUILayout.Button("Items"))
                {
                    scene = "items";
                }
                if (GUILayout.Button("Equip"))
                {
                    scene = "equip";
                }
                if (GUILayout.Button("Character"))
                {
                    scene = "character";
                }
                if (GUILayout.Button("Party"))
                {
                    scene = "party";
                }
                if (GUILayout.Button("Options"))
                {
                    scene = "options";
                }
                if (GUILayout.Button("Exit"))
                {
                    scene = "exit";
                }

                GUILayout.EndVertical();
            }
            else if (scene == "items")
            {
                GUILayout.BeginVertical();
                GUILayout.Label("Items");
                GUILayout.EndVertical();
            }
            else if (scene == "equip")
            {
                GUILayout.BeginVertical();
                GUILayout.Label("Equip");
                GUILayout.EndVertical();
            }
            else if (scene == "character")
            {
                GUILayout.BeginVertical();
                GUILayout.Label("Character");
                GUILayout.EndVertical();
            }
            else if (scene == "party")
            {
                GUILayout.BeginVertical();
                GUILayout.Label("Party");
                GUILayout.EndVertical();
            }
            else if (scene == "options")
            {
                GUILayout.BeginVertical();
                GUILayout.Label("Options");
                GUILayout.EndVertical();
            }
            else if (scene == "exit")
            {
                GUILayout.BeginVertical();
                GUILayout.Label("Mark is a cunt");
                GUILayout.EndVertical();
            }
        }
        GUILayout.EndArea();
    }

    void Update()
    {
        // First press pauses game
        if (Input.GetButtonUp("Menu") && !isPaused)
        {
            Time.timeScale = 0.0f;
            isPaused = true;
            state = (state == State.Hide) ? State.Show : State.Hide;
            scene = "start";
        }
        // Second press (while paused) unpauses game
        else if (Input.GetButtonUp("Menu") && isPaused)
        {
            Time.timeScale = 1.0f;
            isPaused = false;
            state = (state == State.Hide) ? State.Show : State.Hide;
            scene = "start";
        }
    }
}