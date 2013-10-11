using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    Transform myTransform;
    Vector3 currentDirection;
    float moveSpeed = 2;
	// Use this for initialization
	void Start () {
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            float xDir = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            float zDir = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
            myTransform.Translate(xDir, 0, zDir);
        }
	}
}
