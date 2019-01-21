using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionEvent
{
    public enum senses { VISION, SOUND };
    public enum types { NEW, LOST };

    public GameObject go;
    public senses sense;
    public types type;
}

public class Vision : MonoBehaviour {

    public Camera frustum;
    public LayerMask ray_mask;
    public LayerMask mask;

    private List<GameObject> detected;
    private List<GameObject> detected_now;
    private Ray ray;

    // Use this for initialization
    void Start()
    {
        detected = new List<GameObject>();
        detected_now = new List<GameObject>();
        ray = new Ray();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, frustum.farClipPlane, mask);
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(frustum);

        detected_now.Clear();

        foreach (Collider col in colliders)
        {
            if (col.gameObject != gameObject && GeometryUtility.TestPlanesAABB(planes, col.bounds))
            {
                RaycastHit hit;
                ray.origin = transform.position;
                ray.direction = (col.transform.position - transform.position).normalized;
                ray.origin = ray.GetPoint(frustum.nearClipPlane);

                if (Physics.Raycast(ray, out hit, frustum.farClipPlane, ray_mask))
                {
                        detected_now.Add(col.gameObject);
                }
            }
        }

        // Compare detected with detected_now -------------------------------------
        foreach (GameObject go in detected_now)
        {
            if (detected.Contains(go) == false)
            {
                PerceptionEvent perception = new PerceptionEvent();
                perception.go = go;
                perception.sense = PerceptionEvent.senses.VISION;
                perception.type = PerceptionEvent.types.NEW;

                SendMessage("PerceptionEvent", perception);
            }
        }

        foreach (GameObject go in detected)
        {
            if (detected_now.Contains(go) == false)
            {
                PerceptionEvent perception = new PerceptionEvent();
                perception.go = go;
                perception.sense = PerceptionEvent.senses.VISION;
                perception.type = PerceptionEvent.types.LOST;

                SendMessage("PerceptionEvent", perception);
            }
        }

        detected.Clear();
        detected.AddRange(detected_now);
    }
}
