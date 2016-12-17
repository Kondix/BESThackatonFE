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
    void Start()
    {
        searchToggle[0].isOn = true;
        searchToggle[1].isOn = false;
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

    public void MoveBTN()
    {

    }
    public void BackBTN()
    {

    }
    public void SingInBTN()
    {

    }
    public void SearchInBase()
    {

    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }

}
