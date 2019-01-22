using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_script : MonoBehaviour {

    // Use this for initialization

    private float current_time;
    public float time_to_explode;
    public float soundtime;

	void Start () {
        current_time = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {

        current_time += Time.deltaTime;

        if(current_time >= time_to_explode)
        {
            GetComponent<SphereCollider>().enabled = true;

            if(current_time >= time_to_explode + soundtime)
            {
                Nurse_move.movements = NurseMovements.Patrol;
                Destroy(transform.parent.gameObject);
            }
        }

	}
}
