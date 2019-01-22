using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player_kill : MonoBehaviour
{

    private bool attack = false;
    private bool attacking = false;
    public float timerDeath = 1.0f;
    private float time = 0.0f;
    private Animator animator;

    private GameObject player;

    // Use this for initialization
    void Start()
    {
        
        animator = GetComponentInChildren<Animator>();
        player = GameObject.Find("Main_Character 1");
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {
            if (!attacking)
            {
                attacking = true;
                time = Time.time;
            }
        }
        else
        {
            attacking = false;
        }

        if (attacking && !player.GetComponent<Player_move>().death2 && Time.time >= (time + timerDeath))
        {
            animator.SetBool("isAttacking", true);
            GetComponent<NavMeshAgent>().destination = transform.position;
            Player_move.death = true;
            player.GetComponent<Player_move>().death2 = true;
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        attack = true;
    }
}
