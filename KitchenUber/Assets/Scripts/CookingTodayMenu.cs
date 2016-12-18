using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CookingTodayMenu : MonoBehaviour
{

    [SerializeField]
    InputField inpTitle, inpSize, inpIntg, inpDetail;
    [SerializeField]
    Button removeBTN, backBTN, publicBTN, rlyAddintgBTN, addBTN, switchBTN;

    string titleTXT, descriptionTXT;
    int sizeTXT, ingCout = 0;
    bool switchBool = false;
    [SerializeField]
    GameObject addNewIngrePanel, intgPanel, detailPanel;
    [SerializeField]
    Transform ingListParent;
    [SerializeField]
    GameObject ingPos;
    Button selectedIngredient = null;

 

    void Update()
    {
        if (inpDetail.text == "" || inpSize.text == "" || inpTitle.text == "" || ingCout <= 0)
            publicBTN.interactable = false;
        else
            publicBTN.interactable = true;


        if (selectedIngredient != null)
            removeBTN.interactable = true;
        else
            removeBTN.interactable = false;


        if (switchBTN)
        {
            if (inpIntg.text == "")
                rlyAddintgBTN.interactable = false;
            else
                rlyAddintgBTN.interactable = true;
        }
    }
    #region New ingredient
    public void IngerBTN(GameObject btn)
    {
        selectedIngredient = btn.GetComponent<Button>();
    }
    public void IngBTN(bool set)
    {
        addNewIngrePanel.SetActive(set);
        backBTN.interactable = !addNewIngrePanel.activeSelf;
        publicBTN.interactable = !addNewIngrePanel.activeSelf;
        inpSize.interactable = !addNewIngrePanel.activeSelf;
        inpTitle.interactable = !addNewIngrePanel.activeSelf;
    }

    public void RemBTN()
    {
        Destroy(selectedIngredient.gameObject);
        ingCout--;
    }
public void AddNewIng()
{
        var but = (Instantiate(ingPos, ingListParent));
        but.transform.SetParent(ingListParent);
        but.GetComponentInChildren<Text>().text = inpIntg.text;
        inpIntg.text = null;
        but.GetComponent<Button>().onClick.AddListener(() => myButtonDelegate(but));
        IngBTN(false);
        ingCout++;
}
    void myButtonDelegate(GameObject but)
    {
        IngerBTN(but);
    }
    #endregion
    #region MainPanel
    public void SetTitle()
    {
        titleTXT = inpTitle.text;
    }
    public void SetSize()
    {
        string txt = inpSize.text;
        if (int.TryParse(txt, out sizeTXT))
        {
            sizeTXT = int.Parse(txt);
            if (sizeTXT <= 0 || sizeTXT > 255)
            {
                sizeTXT = 4;
                inpSize.text = sizeTXT.ToString();
            }
        }
        else
            inpSize.text = null;
    }
    public void ShowIngPanel()
    {
        addBTN.interactable = true;
        removeBTN.interactable = true;
        intgPanel.SetActive(true);
        detailPanel.SetActive(false);
    }
    public void ShowDetailPanel()
    {
        selectedIngredient = null;
        addBTN.interactable = false;
        removeBTN.interactable = false;
        intgPanel.SetActive(false);
        detailPanel.SetActive(true);
    }
    #endregion
    #region Detail panel
    public void DetailSet()
    {
        descriptionTXT = inpDetail.text;
    }
    #endregion
    #region Lower Panel
    public void CreateRoomBTN()
    {
        print(titleTXT);
        print(sizeTXT);
        print(descriptionTXT);
    }
    public void BackBTN()
    {
        SceneManager.LoadScene("MainScene");
    }
#endregion
}
