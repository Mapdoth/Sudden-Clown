using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nurse_move : MonoBehaviour {

    static public bool player_seen = false;
    public Transform player;
    public Transform cone;
    public Transform nurse;


    // Update is called once per frame
    void FixedUpdate()
    {

        if (player_seen)
            GetComponent<NavMeshAgent>().destination = player.transform.position;

        if (!GetComponent<NavMeshAgent>().velocity.Equals(Vector3.zero))
        {
            cone.transform.LookAt(player.transform);
            nurse.transform.rotation = new Quaternion(0.7071f, 0.0f, 0.0f, 0.7071f);
        }
    }
}
