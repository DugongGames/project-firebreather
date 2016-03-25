﻿using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    Animator animator;
    //Transform myTransform;
    public Vector3 currentDirection;   
    float moveSpeed;
    bool facingRight = true;

    //variables for movement with a charater controller
    //float gravity = 20.0f;
    Vector3 moveDirection;


	// Use this for initialization
	void Start () {
        //myTransform = transform;
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
        //movement with a character controller
        
        CharacterController controller = GetComponent<CharacterController>();
        
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

        if (currentDirection == new Vector3(1, 0, 0) || currentDirection == new Vector3(-1,0,0))
        {
            animator.SetInteger("Direction", 0);
            animator.SetFloat("Speed", 1.0f);
            moveSpeed = 7.0f;
        }
        else if (currentDirection == new Vector3(1, 0, 1) || currentDirection == new Vector3(-1, 0, 1))
        {
            animator.SetInteger("Direction", 1);
            animator.SetFloat("Speed", 1.0f);
            moveSpeed = 5.0f;
        }
        else if (currentDirection == new Vector3(0, 0, 1))
        {
            animator.SetInteger("Direction", 2);
            animator.SetFloat("Speed", 1.0f);
            moveSpeed = 7.0f;
        }
        else if (currentDirection == new Vector3(0,0,-1))
        {
            animator.SetInteger("Direction", 3);
            animator.SetFloat("Speed", 1.0f);
            moveSpeed = 7.0f;
        }
        else if (currentDirection == new Vector3(1, 0, -1) || currentDirection == new Vector3(-1, 0, -1))
        {
            animator.SetInteger("Direction", 4);
            animator.SetFloat("Speed", 1.0f);
            moveSpeed = 5.0f;
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

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}