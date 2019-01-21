using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surprise : MonoBehaviour {

    static public int key_react = -1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
       if(key_react == 0 && Input.GetKeyDown("x"))
        {
            Debug.Log("Combo Breaker");
        }

	}
}
