using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour {

    // Use this for initialization

    public GameObject player;
    public Vector3 offset;
    public float SmoothSpeed;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, 5, smoothedPosition.z);
      
    }

}
