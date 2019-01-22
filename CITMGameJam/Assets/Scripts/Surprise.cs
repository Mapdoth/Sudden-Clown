using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;
using UnityEngine;

public class Surprise : MonoBehaviour {

    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    //button things


    static public int key_react = -1;
    static public bool atacking = false;

    private Animator animation;
   

    // Use this for initialization
    void Start () {

        animation = GetComponentInChildren<Animator>();

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

        if (key_react == 0 && prevState.Buttons.X == ButtonState.Pressed)
        {
            atacking = true;
            animation.SetBool("Attacking", atacking);
        }

        if (key_react == 1 && prevState.Buttons.Y == ButtonState.Pressed)
        {
            atacking = true;
            animation.SetBool("Attacking", atacking);
        }

        if (key_react == 2 && prevState.Buttons.A == ButtonState.Pressed)
        {
            atacking = true;
            animation.SetBool("Attacking", atacking);
        }

        if (key_react == 0 && prevState.Buttons.B == ButtonState.Pressed)
        {
            atacking = true;
            animation.SetBool("Attacking", atacking);
        }

        if (animation.GetCurrentAnimatorStateInfo(0).IsName("clown_attack"))
        {
            atacking = false;
            animation.SetBool("Attacking", atacking);
        }

    }
}
