using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImHungry : MonoBehaviour
{
    [SerializeField]
    Toggle[] searchToggle; // [0] - First Option [1] - Second Option
    [SerializeField]
    Button contactBTN, singInBTN, leftBTN, rightBTN, backBTN;
    [SerializeField]
    InputField inpSearch;
    [SerializeField]
    GameObject offerPrefab;
    [SerializeField]
    GameObject detailedPanel;


    void Start()
    {
        searchToggle[0].isOn = true;
        searchToggle[1].isOn = false;
        detailedPanel.SetActive(false);
    }
    public void OnChangeToggle(int j)
    {
        for (int i = 0; i < searchToggle.Length; i++)
        {
            if (j != i)
            {
                searchToggle[i].isOn = !searchToggle[j].isOn;
                searchToggle[i].interactable = true;
            }
            else
            {
                searchToggle[i].interactable = false;
            }
        }
        inpSearch.interactable = !searchToggle[1].isOn;
        if (!inpSearch.interactable)
            inpSearch.text = null;
    }

    public void MoveBTN(bool right)
    {
        if(right)
        {

        }
        else
        {

        }
    }
    public void BackBTN()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void SingInBTN()
    {

    }
    public void DetailsBTN()
    {
        detailedPanel.SetActive(true);
    }
    public void BackDetBTN()
    {
        detailedPanel.SetActive(false);
    }
    public void SearchInBase(string search)
    {
        search = inpSearch.text;
    }

    public class ImHungryMenuConnector : Connector
    {
        public class AvlRequest
        {
           
            public string ID;
            public AvlRequest(string t_title, string t_hID, string t_descr, string t_hLVL, string t_maxUsr)
            {
                ID = "AVL";
               
            }
        }
        public class SpecAvlRequest
        {
            
            public string ID;
            public string descr;

            public SpecAvlRequest(string t_descr)
            {
                ID = "SPEC_AVL";
                descr = t_descr;
            }
        }
    }
}
