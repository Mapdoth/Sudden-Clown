using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NurseMovements { None, Patrol, FollowPlayer, GoToSound, GoHelp};
public class Nurse_move : MonoBehaviour {

    public float range = 3.0f;
    public GameObject player;
    public Transform cone;
    public Transform nurse;
    static public GameObject sound_emiter;
    static public NurseMovements movements;

    private Animator animator;
    private Vector3 aux_position;
    private SpriteRenderer flip;
    private bool attacking;

    static public Vector3 posPlayerAtack;
    public float timerDeath = 1.0f;
    private float time = 0.0f;

    private NavMeshAgent nav;
    private void Start()
    {
        aux_position = transform.position;
        animator = GetComponentInChildren<Animator>();
        flip = GetComponentInChildren<SpriteRenderer>();
        nav = GetComponent<NavMeshAgent>();
    }
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
                nav.destination = player.transform.position;
                cone.transform.LookAt(player.transform);
                break;
            case NurseMovements.GoHelp:
                nav.destination = posPlayerAtack;
                if (!nav.hasPath || nav.velocity.Equals(Vector3.zero))
                    movements = NurseMovements.Patrol; 
                break;
            case NurseMovements.GoToSound:
                nav.destination = sound_emiter.transform.position;

                if (nav.velocity.Equals(Vector3.zero))
                {
                    movements = NurseMovements.Patrol;
                }


                break;
        }

        nurse.transform.rotation = new Quaternion(0.7071f, 0.0f, 0.0f, 0.7071f);


        //ANIMATIONS
        if(transform.position.x > aux_position.x)
        {
            animator.SetBool("Walk", true);
            flip.flipX = false;
            aux_position = transform.position;
        }
        else if (transform.position.x == aux_position.x && transform.position.z == aux_position.z)
        {
            animator.SetBool("Walk", false);
        }
        else
        {
            animator.SetBool("Walk", true);
            flip.flipX = true;
            aux_position = transform.position;
        }
    }
}
