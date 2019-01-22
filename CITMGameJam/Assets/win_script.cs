using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class win_script : MonoBehaviour {

    public Text curr_kills;
    public Image win_screen;

    // Use this for initialization
    void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

        int value = 0;
        int.TryParse(curr_kills.text, out value);

        if (value >= 9)
        {
            Time.timeScale = 0;
            win_screen.gameObject.SetActive(true);
        }

	}
}
