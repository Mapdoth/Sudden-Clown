using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour {

    // Use this for initialization


    public float speed;
    private Vector3 dir;

	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        dir = Vector3.zero;

        if (Input.GetKey("w"))
        {
            dir.z = 1.0f;
        }

        if (Input.GetKey("s"))
        {
            dir.z = -1.0f;
        }

        if (Input.GetKey("a"))
        {
            dir.x = -1.0f;
        }

        if (Input.GetKey("d"))
        {
            dir.x = 1.0f;
        }

        if(dir != Vector3.zero)
        {
            transform.Translate(dir.normalized * speed);
        }

    }
}
