using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Main_Character 1")
        {
            Destroy(col.gameObject);
            //Haz cosas
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Main_Character 1")
        {
            Destroy(col.gameObject);
            //Deja de hacer cosas
        }
    }
}
