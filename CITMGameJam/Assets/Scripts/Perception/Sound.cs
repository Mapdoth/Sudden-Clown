using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, GetComponentInParent<BoxCollider>().size.z/2);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.CompareTag("SoundEmmiter"))
            {
                PerceptionEvent perception = new PerceptionEvent();
                perception.go = hitColliders[i].gameObject;
                perception.sense = PerceptionEvent.senses.SOUND;
                perception.type = PerceptionEvent.types.NEW;

                SendMessage("PerceptionEvent", perception);
            }
            ++i;
        }

    }
}
