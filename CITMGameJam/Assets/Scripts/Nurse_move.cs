using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NurseMovements { None, Patrol, FollowPlayer, GoToSound};
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


    private void Start()
    {
        aux_position = transform.position;
        animator = GetComponentInChildren<Animator>();
        flip = GetComponentInChildren<SpriteRenderer>();
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
                GetComponent<NavMeshAgent>().destination = player.transform.position;
                cone.transform.LookAt(player.transform);
                break;

            case NurseMovements.GoToSound:
                GetComponent<NavMeshAgent>().destination = sound_emiter.transform.position;

                if (GetComponent<NavMeshAgent>().velocity.Equals(Vector3.zero))
                {
                    movements = NurseMovements.Patrol;
                    sound_emiter.SetActive(false);
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

        //PLAYER ATTACK
        float distance = (transform.position - player.transform.position).magnitude;
        if (distance <= range)
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }

        if(attacking && !Player_move.death)
        {
            animator.SetBool("isAttacking", true);
            GetComponent<NavMeshAgent>().destination = transform.position;
            Player_move.death = true;
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

    }
}
