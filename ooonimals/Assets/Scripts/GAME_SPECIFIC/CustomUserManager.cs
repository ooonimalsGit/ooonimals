using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUserManager : BaseUserManager {

	// Use this for initialization
	void Start () {
        // keep this object alive
        DontDestroyOnLoad(this.gameObject);
        SetScore(47);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
