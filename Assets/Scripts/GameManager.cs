using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject DialogBox;
    public TextMeshProUGUI DialogText;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowText(string text)
    {
        DialogBox.SetActive(true);
        DialogText.text = text;
    }

    public void HideText()
    {
        DialogBox.SetActive(false);
        DialogText.text = "";
    }
}
