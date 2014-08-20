using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    Animator animator;
    Transform myTransform;
    public Vector3 currentDirection;
    float moveSpeed = 3;
    bool facingRight = true;
    
	// Use this for initialization
	void Start () {
        myTransform = transform;
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //gets the input for movement
        float xDir = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zDir = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        //uses the input to determine what direction the character is moving for animation
        currentDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //messiest if statement ever to determine what direction character is walking
        if (currentDirection == new Vector3(1, 0, 0) || currentDirection == new Vector3(-1,0,0))
        {
            animator.SetInteger("Direction", 0);
        }
        else if (currentDirection == new Vector3(1, 0, 1) || currentDirection == new Vector3(-1, 0, 1))
        {
            animator.SetInteger("Direction", 1);
        }
        else if (currentDirection == new Vector3(0, 0, 1))
        {
            animator.SetInteger("Direction", 2);
        }
        else if (currentDirection == new Vector3(0,0,-1))
        {
            animator.SetInteger("Direction", 3);
        }
        else if (currentDirection == new Vector3(1, 0, -1) || currentDirection == new Vector3(-1, 0, -1))
        {
            animator.SetInteger("Direction", 4);
        }

        if (xDir > 0 && !facingRight)
            Flip();
        else if (xDir < 0 && facingRight)
            Flip();
        //moves the character relative to world space, to ignore the rotation of the sprites
        myTransform.Translate(xDir + zDir,0,zDir - xDir, Space.World);     
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
