using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse_move : MonoBehaviour {

    static public bool player_seen;
    public GameObject player;
    public GameObject cone;
    public float speed;

    private float rotation;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
        if (player_seen)
        {
            Vector2 dir = new Vector2(player.transform.position.x, player.transform.position.z) - new Vector2 (transform.position.x, transform.position.z);
          
            transform.transform.Translate(dir.normalized * speed);
            cone.transform.LookAt(player.transform);
            
        }

    }
}
