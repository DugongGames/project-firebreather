using UnityEngine;
using System.Collections;

public class NpcController : MonoBehaviour {

    Animator animator;
    int pos;
    float lastDir;
    public Vector3 currentDirection;
    public Camera cam;
    bool facingRight = true;
    bool rotateCamLeft;

    readonly Vector2[] directions = new Vector2[] {
        new Vector2(0, 0),
        new Vector2(1, 0),
        new Vector2(2, 0),
        new Vector2(1, 1),
        new Vector2(0, 1),
        new Vector2(4, 1),
        new Vector2(3, 0),
        new Vector2(4, 0),
    };

    // Use this for initialization
    void Start () {
        animator = this.GetComponent<Animator>();

        // Proably shouldnt be hardcoded, but sets pos to
        // -1 otherwise, should be getting it from somewhere?
        animator.SetInteger("Direction", 0);
        pos = 0;
    }

    // Update is called once per frame
    void Update () {

        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward,
            cam.transform.rotation * Vector3.up);
        animator.SetFloat("Speed", 0f);

        if (Input.GetButtonUp("CameraLeft"))
        {
            rotateCamLeft = true;
            RotateCamera(rotateCamLeft);
        }

        if (Input.GetButtonUp("CameraRight"))
        {
            rotateCamLeft = false;
            RotateCamera(rotateCamLeft);
        }
    }

    private void RotateCamera(bool left)
    {
        if (left)
        {
            if (pos == 7)
                pos = -1;
            transform.Rotate(Vector3.up, 45.0f, Space.World);
            ++pos;
        }
        else if (!left)
        {
            if (pos == 0)
                pos = 8;
            transform.Rotate(Vector3.up, -45.0f, Space.World);
            --pos;
        }

        var dir = directions[pos];
        animator.SetInteger("Direction", (int)dir.x);

        if (dir.y != lastDir)
        {
            Flip();
        }

        lastDir = dir.y;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionStay(Collision col)
    {
        if (Input.GetButtonDown("Interact"))
        {
            col.gameObject.SendMessage("Interact");
        }
    }
}
