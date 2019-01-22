using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class old_man_kill : MonoBehaviour {


    public GameObject player;
    public GameObject x_but;
    public GameObject y_but;
    public GameObject a_but;
    public GameObject b_but;
    public float distance_to_trigger;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 p_distance_vec = player.transform.position - transform.position;
        float p_distance = p_distance_vec.magnitude;

        if(p_distance <= distance_to_trigger && Surprise.key_react < 0)
        {

            Surprise.key_react = Random.Range(0, 4);

            if (Surprise.key_react == 0)
            {
                x_but.SetActive(true);
            }

            if (Surprise.key_react == 1)
            {
                y_but.SetActive(true);
            }

            if (Surprise.key_react == 2)
            {
                a_but.SetActive(true);
            }

            if (Surprise.key_react == 3)
            {
                b_but.SetActive(true);
            }

        }

        else if (p_distance > distance_to_trigger)
        {
            x_but.SetActive(false);
            y_but.SetActive(false);
            a_but.SetActive(false);
            b_but.SetActive(false);
            Surprise.key_react = -1;
        }


	}
}
