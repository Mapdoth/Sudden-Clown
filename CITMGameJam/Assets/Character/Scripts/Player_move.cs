using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;
using UnityEngine;

public class Player_move : MonoBehaviour {

    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    //button things


    public float speed;
    private Vector3 dir;
    private Animator animation;
    private SpriteRenderer flip;

	void Start ()
    {
        animation = GetComponentInChildren<Animator>();
        flip = GetComponentInChildren<SpriteRenderer>();
    }

   void FixedUpdate()
    {
        GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
    }

    // Update is called once per frame
    void Update() {

        // Find a PlayerIndex, for a single player game
        // Will find the first controller that is connected ans use it
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

        dir = Vector3.zero;

        float x_motion = state.ThumbSticks.Left.X;
        float y_motion = state.ThumbSticks.Left.Y;

        if (y_motion != 0)
        {
            animation.SetBool("Walk", true);
       
        }

        if (x_motion < 0)
        {
            flip.flipX = true;
            animation.SetBool("Walk", true);
        }

        if (x_motion > 0)
        {
            flip.flipX = false;
            animation.SetBool("Walk", true);
        }

        dir.x = x_motion;
        dir.z = y_motion;

        if (dir != Vector3.zero)
        {
            transform.Translate(dir.normalized * speed);
        }
        else
        {
            animation.SetBool("Walk", false);
        }
    }
}
