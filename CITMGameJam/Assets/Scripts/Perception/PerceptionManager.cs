using UnityEngine;
using System.Collections;

public class PerceptionManager : MonoBehaviour {

    void PerceptionEvent(PerceptionEvent ev)
    {
        Debug.Log(" __ ");
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
