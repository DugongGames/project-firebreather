using UnityEngine;
using System.Collections;

public class NpcScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay(Collision col)
    {
        if (Input.GetButtonDown("Interact"))
        {
            col.gameObject.SendMessage("Interact");
        }
    }
}
