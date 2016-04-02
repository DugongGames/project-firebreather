using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class NpcController : MonoBehaviour
{
    private CommonControls con;

    // Use this for initialization
    void Start () {
        con = new CommonControls {animator = this.GetComponent<Animator>()};

        // Proably shouldnt be hardcoded, but sets pos to
        // -1 otherwise, should be getting it from somewhere?
        con.animator.SetInteger("Direction", 0);
        con.pos = 0;
    }

    // Update is called once per frame
    void Update () {
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

    void OnCollisionStay(Collision col)
    {
        if (Input.GetButtonDown("Interact"))
        {
            col.gameObject.SendMessage("Interact");
        }
    }
}
