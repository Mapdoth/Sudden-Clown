using UnityEngine;
using System.Collections;

public class PerceptionManager : MonoBehaviour {

    void PerceptionEvent(PerceptionEvent ev)
    {
        if (ev.type == global::PerceptionEvent.types.NEW)
        {
            if (ev.sense == global::PerceptionEvent.senses.VISION)
                Nurse_move.movements = NurseMovements.FollowPlayer;
            else if (ev.go)
                ev.go.GetComponentInParent<Patrol>().gameObject.SetActive(false);
        }
        else
        {
            if (ev.sense == global::PerceptionEvent.senses.VISION)
                Nurse_move.movements = NurseMovements.Patrol;
            else if (ev.go)
                ev.go.GetComponentInParent<Patrol>().gameObject.SetActive(true);
        }
    }
}
