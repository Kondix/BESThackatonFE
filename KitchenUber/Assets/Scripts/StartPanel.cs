using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour {

    public GameObject startPanel;
    public GameObject yourProfile;

         
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void LogInButtonMethod()
    {
        startPanel.SetActive(false);
        yourProfile.SetActive(true);
    }
    public void CookingButtonMethon()
    {
        SceneManager.LoadScene("CookingToday");     
    }
    public void HungryButtonMethod()
    {

    }


}
