using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveToMouseClick : MonoBehaviour
{

    public GameObject[] SendGoal;
    public SphereCollider collider;
    public int mouse_button = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(mouse_button))
        {
            RaycastHit hit;
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r, out hit) == true)
            {
                transform.position = hit.point;
            }

            foreach (GameObject go in SendGoal)
            {
                if (go != null && go.GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
                {
                    if(CheckSphereColl(go))
                        go.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = transform.position;
                }
            }
        }
    }

    private bool CheckSphereColl(GameObject go)
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, collider.radius);
       
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.CompareTag("Audio Emitter"))
            {
                return true;
            }
            ++i;
        }

        return false;
    }
}
