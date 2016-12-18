using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour {

    public GameObject startPanel;
    public GameObject yourProfile;
    public Sprite startPanelSprite;
    public Sprite yourProfileSprite;
    public Sprite thirdBG;

         
	// Use this for initialization
	void Start () {
            CommonElements.instance.ChangeBackground(startPanelSprite);
        if (CommonElements.instance.isLoggedIn)
            LogInButtonMethod();

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void LogInButtonMethod()
    {
        startPanel.SetActive(false);
        yourProfile.SetActive(true);
        CommonElements.instance.isLoggedIn = true;
        CommonElements.instance.ChangeBackground(thirdBG);
    }
    public void CookingButtonMethon()
    {
        SceneManager.LoadScene("CookingToday");     
    }
    public void HungryButtonMethod()
    {
        SceneManager.LoadScene("ImHungry");     
    }
    public void DatChatRoom()
    {
        SceneManager.LoadScene("ChatScene");
    }


}
