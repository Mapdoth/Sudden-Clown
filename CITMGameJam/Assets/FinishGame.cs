using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour {

    Animator anim;

    static public bool death = false;
    // Use this for initialization
    void Start () {
         anim =  GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.GetBool("Nurse_hit"))
        {
            death = true;
        }
	}
}
