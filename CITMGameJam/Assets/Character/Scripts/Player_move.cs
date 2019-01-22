using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour {

    // Use this for initialization


    public float speed;
    private Vector3 dir;
    private Animator animation;
    private SpriteRenderer flip;

	void Start ()
    {
        animation = GetComponentInChildren<Animator>();
        flip = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {

        dir = Vector3.zero;

        if (Input.GetKey("w"))
        {
            animation.SetBool("Walk", true);
            dir.z = 1.0f;
        }

        if (Input.GetKey("s"))
        {
            animation.SetBool("Walk", true);
            dir.z = -1.0f;
        }

        if (Input.GetKey("a"))
        {
            dir.x = -1.0f;
            flip.flipX = true;
            animation.SetBool("Walk", true);
        }

        if (Input.GetKey("d"))
        {
            flip.flipX = false;
            dir.x = 1.0f;
            animation.SetBool("Walk", true);
        }
        if (dir != Vector3.zero)
        {
            transform.Translate(dir.normalized * speed);
        }
        else
        {
            animation.SetBool("Walk", false);
        }
    }
}
