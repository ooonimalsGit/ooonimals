using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_Derived : BaseGameController {

	// Use this for initialization
	void Start () {
        CustomUserManager userData = FindObjectOfType<CustomUserManager>();

        if (userData)
        {
            Debug.Log("currentScore=" + userData.GetScore());
        }else
        {
            Debug.Log("No user Data");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
