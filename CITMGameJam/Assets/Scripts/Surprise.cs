using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surprise : MonoBehaviour {

    static public int key_react = -1;
    static public bool atacking = false;

    private Animator animation;
   

    // Use this for initialization
    void Start () {

        animation = GetComponentInChildren<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
		
       if(key_react == 0 && Input.GetKeyDown("x"))
        {
            atacking = true;
            animation.SetBool("Attacking", atacking);
        }

        if (animation.GetCurrentAnimatorStateInfo(0).IsName("clown_attack"))
        {
            atacking = false;
            animation.SetBool("Attacking", atacking);
        }

    }
}
