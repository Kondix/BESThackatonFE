using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonElements : MonoBehaviour {

    public static CommonElements instance;
    public GameObject mainUI;
    public GameObject camera;

	void Awake() {
        DontDestroyOnLoad(gameObject);

        if (!instance)
            instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public CommonElements GetInstance()
    {
        if (!instance)
            instance = this;
        return instance;
    }
}
