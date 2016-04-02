using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour
{

    Animator animator;
    public Vector3 currentDirection;
    private CharacterController controller;
    float moveSpeed;
    bool facingRight = true;
    bool interacting;
    bool rotateCamLeft;
    float lastDir;
    int pos;

    //variables for movement with a charater controller
    Vector3 moveDirection;

    readonly Vector2[] directions = {
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
    void Start()
    {
        animator = this.GetComponent<Animator>();

        // Proably shouldnt be hardcoded, but sets pos to
        // -1 otherwise, should be getting it from somewhere?
        animator.SetInteger("Direction", 0);
        pos = 0;

        controller = gameObject.GetComponent<CharacterController>();

    }


    // Update is called once per frame
    void Update()
    {
        //movement with a character controller

        if (!interacting)
        {
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            //Movement with transform
            /*gets the input for movement
            float xDir = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            float zDir = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
            */
            //uses the input to determine what direction the character is moving for animation
            currentDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            // Right
            if (currentDirection == new Vector3(1, 0, 0))
            {
                animator.SetInteger("Direction", 0);
                animator.SetFloat("Speed", 1.0f);
                moveSpeed = 7.0f;
                pos = GetObjectPosition(currentDirection);
                lastDir = 0;
            }

            //Left
            else if (currentDirection == new Vector3(-1, 0, 0))
            {
                animator.SetInteger("Direction", 0);
                animator.SetFloat("Speed", 1.0f);
                moveSpeed = 7.0f;
                pos = GetObjectPosition(currentDirection);
                lastDir = 1;
            }

            // Up right
            else if (currentDirection == new Vector3(1, 0, 1))
            {
                animator.SetInteger("Direction", 1);
                animator.SetFloat("Speed", 1.0f);
                moveSpeed = 5.0f;
                pos = GetObjectPosition(currentDirection);
                lastDir = 0;
            }

            // Up left
            else if (currentDirection == new Vector3(-1, 0, 1))
            {
                animator.SetInteger("Direction", 1);
                animator.SetFloat("Speed", 1.0f);
                moveSpeed = 5.0f;
                pos = GetObjectPosition(currentDirection);
                lastDir = 1;
            }

            // Up
            else if (currentDirection == new Vector3(0, 0, 1))
            {
                animator.SetInteger("Direction", 2);
                animator.SetFloat("Speed", 1.0f);
                moveSpeed = 7.0f;
                pos = GetObjectPosition(currentDirection);
            }

            // Down
            else if (currentDirection == new Vector3(0, 0, -1))
            {
                animator.SetInteger("Direction", 3);
                animator.SetFloat("Speed", 1.0f);
                moveSpeed = 7.0f;
                pos = GetObjectPosition(currentDirection);
            }

            // Down right
            else if (currentDirection == new Vector3(1, 0, -1))
            {
                animator.SetInteger("Direction", 4);
                animator.SetFloat("Speed", 1.0f);
                moveSpeed = 5.0f;
                pos = GetObjectPosition(currentDirection);
                lastDir = 0;
            }

            // Down left
            else if (currentDirection == new Vector3(-1, 0, -1))
            {
                animator.SetInteger("Direction", 4);
                animator.SetFloat("Speed", 1.0f);
                moveSpeed = 5.0f;
                pos = GetObjectPosition(currentDirection);
                lastDir = 1;
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }

            if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight)
                Flip();
            else if (Input.GetAxisRaw("Horizontal") < 0 && facingRight)
                Flip();

            //moves the character relative to world space, to ignore the rotation of the sprites
            //myTransform.Translate(xDir + zDir,0,zDir - xDir, Space.World);
            //moves the character controller, ignoring y axis movement
            controller.SimpleMove(moveDirection * moveSpeed);
        }

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

    private static int GetObjectPosition(Vector3 currentPosition)
    {
        // 0,0
        if (currentPosition == new Vector3(1, 0, 0))
        {
            return 0;
        }
        // 0,1
        if (currentPosition == new Vector3(-1, 0, 0))
        {
            //correct
            return 4;
        }
        // 1,0
        if (currentPosition == new Vector3(1, 0, 1))
        {
            //correct
            return 1;
        }
        // 1,1
        if (currentPosition == new Vector3(-1, 0, 1))
        {
            //correct
            return 3;
        }
        // 2,0
        if (currentPosition == new Vector3(0, 0, 1))
        {
            //correct
            return 2;
        }
        // 3,0
        if (currentPosition == new Vector3(0, 0, -1))
        {
            //correct
            return 6;
        }
        // 4,0
        if (currentPosition == new Vector3(1, 0, -1))
        {
            //correct
            return 7;
        }
        //4,1
        if (currentPosition == new Vector3(-1, 0, -1))
        {
            //correct
            return 5;
        }
        return -1;
    }

    void OnGUI()
    {
        if (interacting)
        {
            if (GUI.Button(new Rect(200, 100, 100, 50), "Hello"))
            {
                interacting = false;
            }
        }
    }

    void Interact()
    {  
        interacting = true;
    }

}
