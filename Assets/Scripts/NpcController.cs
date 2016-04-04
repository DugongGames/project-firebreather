using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class NpcController : MonoBehaviour
{
    private CommonControls con;
    private Renderer renderer;

    //Used to get paused state
    private GameObject menuObject;
    private MenuSystem menuScript;

    // Use this for initialization
    void Start () {
        con = new CommonControls {animator = this.GetComponentInChildren<Animator>()};
        renderer = GetComponentInChildren<Renderer>();

        // Proably shouldnt be hardcoded, but sets pos to
        // -1 otherwise, should be getting it from somewhere?
        con.animator.SetInteger("Direction", 0);
        con.pos = 0;

        menuObject = GameObject.FindGameObjectWithTag("Player");
        menuScript = menuObject.GetComponent<MenuSystem>();
    }

    // Update is called once per frame
    void Update () {
        //menuScript = GetComponent<MenuSystem>();
        if (menuScript.isPaused == false)
        {
            transform.LookAt(transform.position + con.cam.transform.rotation * Vector3.forward,
            con.cam.transform.rotation * Vector3.up);
            con.animator.SetFloat("Speed", 0f);

            if (Input.GetButtonUp("CameraLeft"))
            {
                con.RotateCamera(true, transform);
            }
            if (Input.GetButtonUp("CameraRight"))
            {
                con.RotateCamera(false, transform);
            }
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (Input.GetButtonDown("Interact"))
        {
            col.gameObject.SendMessage("Interact");
        }
    }
}
