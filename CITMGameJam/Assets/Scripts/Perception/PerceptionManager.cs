using UnityEngine;
using System.Collections;

public class PerceptionManager : MonoBehaviour {

    private float time = 0.0f;
    public float timer = 2.0f;
    // Update is called once per frame

    void PerceptionEvent(PerceptionEvent ev)
    {

        if (ev.type == global::PerceptionEvent.types.NEW)
        {
            if (ev.sense == global::PerceptionEvent.senses.VISION)
                Nurse_move.player_seen = true;
        }
        else
        {
            if (ev.sense == global::PerceptionEvent.senses.VISION)
                Nurse_move.player_seen = false;
        }
    }
}
