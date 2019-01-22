using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using XInputDotNetPure;
using UnityEngine;


public class old_man_kill : MonoBehaviour {

    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;


   public int key_react = -1;
   public bool player_atacking = false;

    static private int count_kills;
    public Text text_kills;

    public GameObject player;
    public GameObject x_but;
    public GameObject y_but;
    public GameObject a_but;
    public GameObject b_but;
    public float distance_to_trigger;
    private float clock;

    private Animator animation;
    private Animator player_animation;

    // Use this for initialization
    void Start () {
        animation = GetComponentInChildren<Animator>();
        player_animation = player.GetComponentInChildren<Animator>();
}
	
	// Update is called once per frame
	void Update () {
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }

        prevState = state;
        state = GamePad.GetState(playerIndex);


        //button things

        Vector3 p_distance_vec = transform.position - player.transform.position;
        float p_distance = p_distance_vec.magnitude;

        if(p_distance <= distance_to_trigger && key_react < 0)
        {

           key_react = Random.Range(0, 4);

            if (key_react == 0)
            {
                x_but.SetActive(true);

            }

            if (key_react == 1)
            {
                y_but.SetActive(true);
            }

            if (key_react == 2)
            {
                a_but.SetActive(true);

            }

            if (key_react == 3)
            {
                b_but.SetActive(true);

            }

        }

        if (state.Buttons.X == ButtonState.Pressed && key_react == 0 && player_atacking == false)
        {
            player_atacking = true;
            player_animation.SetBool("Attacking", player_atacking);
            count_kills++;
            text_kills.text = count_kills.ToString();
            
        }

        if (state.Buttons.Y == ButtonState.Pressed && key_react == 1 && player_atacking == false)
        {
            player_atacking = true;
            player_animation.SetBool("Attacking", player_atacking);
            count_kills++;
            text_kills.text = count_kills.ToString();
        }

        if (state.Buttons.A == ButtonState.Pressed && key_react == 2 && player_atacking == false)
        {
            player_atacking = true;
            player_animation.SetBool("Attacking", player_atacking);
            count_kills++;
            text_kills.text = count_kills.ToString();
        }

        if (state.Buttons.B == ButtonState.Pressed && key_react == 3 && player_atacking == false)
        {
            player_atacking = true;
            player_animation.SetBool("Attacking", player_atacking);
            count_kills++;
            text_kills.text = count_kills.ToString();
        }

        else if (p_distance > distance_to_trigger)
        {
            x_but.SetActive(false);
            y_but.SetActive(false);
            a_but.SetActive(false);
            b_but.SetActive(false);
            key_react = -1;
        }

        if (player_animation.GetCurrentAnimatorStateInfo(0).IsName("clown_attack"))
        {
            player_atacking = false;
            player_animation.SetBool("Attacking", player_atacking);
        }

        if (player_atacking)
        {
            animation.SetBool("isDead", true);           

        }

        if (animation.GetBool("isDead"))
        {
            clock += Time.deltaTime;
        }

        if(clock >= 3)
        {
            gameObject.SetActive(false);
        }
       




    }
}
