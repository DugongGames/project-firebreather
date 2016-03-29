using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    Animator animator;
    //Transform myTransform;
    public Vector3 currentDirection;   
    float moveSpeed;
    bool facingRight = true;
    bool interacting = false;

    //variables for movement with a charater controller
    //float gravity = 20.0f;
    Vector3 moveDirection;

    Vector2[] Directions = new Vector2[] {
        new Vector2(0, 0),
        new Vector2(1, 0),
        new Vector2(2, 0),
        new Vector2(1, 1),
        new Vector2(0, 1),
        new Vector2(4, 1),
        new Vector2(3, 0),
        new Vector2(4, 0),
    };

    int dirCount;
    float lastDir;

    // Use this for initialization
    void Start () {
        //myTransform = transform;
        animator = this.GetComponent<Animator>();
        dirCount = animator.GetInteger("Direction");
	}

	
	// Update is called once per frame
	void Update () {
        
        //movement with a character controller
        CharacterController controller = GetComponent<CharacterController>();

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


            //messiest if statement ever to determine what direction character is walking
            if (Input.GetButtonDown("Interact"))
            {
                interacting = true;
            }

            if (currentDirection == new Vector3(1, 0, 0) || currentDirection == new Vector3(-1, 0, 0))
            {
                animator.SetInteger("Direction", 0);
                animator.SetFloat("Speed", 1.0f);
                moveSpeed = 7.0f;
                dirCount = animator.GetInteger("Direction");
            }
            else if (currentDirection == new Vector3(1, 0, 1) || currentDirection == new Vector3(-1, 0, 1))
            {
                animator.SetInteger("Direction", 1);
                animator.SetFloat("Speed", 1.0f);
                moveSpeed = 5.0f;
                dirCount = animator.GetInteger("Direction");
            }
            else if (currentDirection == new Vector3(0, 0, 1))
            {
                animator.SetInteger("Direction", 2);
                animator.SetFloat("Speed", 1.0f);
                moveSpeed = 7.0f;
                dirCount = animator.GetInteger("Direction");
            }
            else if (currentDirection == new Vector3(0, 0, -1))
            {
                animator.SetInteger("Direction", 3);
                animator.SetFloat("Speed", 1.0f);
                moveSpeed = 7.0f;
                dirCount = animator.GetInteger("Direction");
            }
            else if (currentDirection == new Vector3(1, 0, -1) || currentDirection == new Vector3(-1, 0, -1))
            {
                animator.SetInteger("Direction", 4);
                animator.SetFloat("Speed", 1.0f);
                moveSpeed = 5.0f;
                dirCount = animator.GetInteger("Direction");
            }
            else
            {
                animator.SetFloat("Speed", 0f);
                dirCount = animator.GetInteger("Direction");
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
                transform.Rotate(Vector3.up, 45.0f, Space.World);
                Vector2 dir = Directions[mod(++dirCount, 8)];
                animator.SetInteger("Direction", (int)dir.x);
                Debug.Log(dirCount);
                Debug.Log(animator.GetInteger("Direction"));
                Debug.Log(dir);

                if (dir.y != lastDir)
                {
                    Flip();
                }
                lastDir = dir.y;

            }
            if (Input.GetButtonUp("CameraRight"))
            {
                transform.Rotate(Vector3.up, -45.0f, Space.World);

                Vector2 dir = Directions[mod(--dirCount, 8)];
                animator.SetInteger("Direction", (int)dir.x);
                Debug.Log(dirCount);
                Debug.Log(animator.GetInteger("Direction"));
                Debug.Log(dir);

                if (dir.y != lastDir)
                {
                    Flip();
                }
                lastDir = dir.y;
            }
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    int mod(int a, int n)
    {
        return ((a % n) + n) % n;
    }

    void OnGUI()
    {
        if (interacting)
        {
            if (GUI.Button(new Rect(100, 500, 100, 50), "Hello"))
            {
                interacting = false;
            }
        }
    }
}
