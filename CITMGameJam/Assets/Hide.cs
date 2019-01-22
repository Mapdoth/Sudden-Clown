using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;
using UnityEngine;


public class Hide : MonoBehaviour {

    public GameObject plant;
    private bool hidden = false;
    private GameObject player;
    private AudioSource hide_sound;

    //button
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    static public int key_react = -1;
    private Vector3 dir;

    private void Start()
    {
        player = GameObject.Find("Main_Character 1");
        hide_sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Main_Character 1")
        {
            col.gameObject.SetActive(false);
            plant.SetActive(true);
            hidden = true;
            hide_sound.Play();
            if(Nurse_move.movements != NurseMovements.GoHelp)
                Nurse_move.movements = NurseMovements.Patrol;
            //Haz cosas
        }
    }

    private void Exit()
    {
        hidden = false;
        player.SetActive(true);
        plant.SetActive(false);
        hide_sound.Play();
        //Deja de hacer cosas
    }

    public void Update()
    {

        if (hidden == true)
        {

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

            float x_motion = prevState.ThumbSticks.Left.X;
            float y_motion = prevState.ThumbSticks.Left.Y;

            dir.x = x_motion;
            dir.z = y_motion;

            if (state.Triggers.Left != 0 && dir != Vector3.zero)
            {
                player.transform.Translate(dir.normalized * 0.5f);
                Exit();
            }
        }
    }
}
