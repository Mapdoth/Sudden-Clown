using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour {

    // Use this for initialization


    public float speed;
 

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("w"))
        {
			transform.Translate(0,0,speed);
        }

        if (Input.GetKey("s"))
        {
			transform.Translate(0, 0, -speed);
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(-speed,0, 0);
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(speed, 0, 0);
        }


    }
}
