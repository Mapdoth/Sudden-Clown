using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using UnityEngine.AI;
using BansheeGz.BGSpline.Curve;

public class Patrol : MonoBehaviour {

    public BGCcMath path;
    public float accuracy = 1.0f;

    private float current_percentage = 0.0f;
    private float distance_ratio = 0.1f;

    // Use this for initialization
    void Start () {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        path.CalcPositionByClosestPoint(transform.position, out current_percentage);
        distance_ratio = agent.speed / path.GetDistance();
        current_percentage /= path.GetDistance();

    }

    // Update is called once per frame
    void Update () {

        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        Vector3 target = Vector3.zero;

        target = path.CalcPositionByDistanceRatio(current_percentage);
        Debug.Log(target);
        float distance = (target - transform.position).magnitude;
        if (distance < accuracy)
        {
            Debug.Log(current_percentage);
            current_percentage += distance_ratio;
            if (current_percentage >= 1.0f)
                current_percentage = 0.0f;
        }
        Debug.Log("");
        Debug.Log(current_percentage);
        GetComponent<NavMeshAgent>().destination = target;
    }
}
