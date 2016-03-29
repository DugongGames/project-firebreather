using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //transform.position = new Vector3(target.position.x - 8.0f,target.position.y + 5.0f,target.position.z - 8.0f);

        float cameraVDistance = 5f; //how far the camera is behind the player
        float cameraHDistance = 0f; //how far the camera is above the player


        Vector3 playerPosition = target.transform.position;
        Vector3 behindPlayer = -target.transform.forward * cameraVDistance;
        Vector3 abovePlayer = Vector3.up * cameraHDistance;
        Vector3 cameraPosition = playerPosition + behindPlayer + abovePlayer;
        Vector3 cameraToPlayer = playerPosition - cameraPosition;
        Quaternion cameraRotation = Quaternion.LookRotation(cameraToPlayer);
        transform.position = cameraPosition;
        transform.rotation = cameraRotation;


        /*
        if (Input.GetButtonUp("CameraLeft"))
            transform.Rotate(target.up, 45.0f, Space.World);
        else if (Input.GetButtonUp("CameraRight"))
            transform.Rotate(target.up, -45.0f,Space.World);
         */
	}
}
