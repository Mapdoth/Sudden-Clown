using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NurseMovements { None, Patrol, FollowPlayer, GoToSound};
public class Nurse_move : MonoBehaviour {

    public Transform player;
    public Transform cone;
    public Transform nurse;
    static public GameObject sound_emiter;
    static public NurseMovements movements;

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (movements)
        {
            case NurseMovements.None:
                break;
            case NurseMovements.Patrol:
                cone.transform.localRotation = new Quaternion(0.0f,0.0f,0.0f,0.0f);

                break;
            case NurseMovements.FollowPlayer:
                GetComponent<NavMeshAgent>().destination = player.transform.position;
                cone.transform.LookAt(player.transform);
                break;

            case NurseMovements.GoToSound:

                GetComponent<NavMeshAgent>().destination = sound_emiter.transform.position;
                

                break;
        }

        nurse.transform.rotation = new Quaternion(0.7071f, 0.0f, 0.0f, 0.7071f);
    }
}
