using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveToMouseClick : MonoBehaviour
{

    public GameObject[] SendGoal;
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

            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, GetComponent<SphereCollider>().radius);
            int i = 0;
            while (i < hitColliders.Length)
            {
                if (hitColliders[i].gameObject.CompareTag("Player"))
                {
                    hitColliders[i].GetComponent<UnityEngine.AI.NavMeshAgent>().destination = transform.position;
                }
                ++i;
            }
        }
    }
}
