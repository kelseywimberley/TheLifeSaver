using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BatAndMouseTracking : MonoBehaviour
{
    public GameObject cornerUI;
    public TextMeshProUGUI batText;
    public TextMeshProUGUI mouseText;
    private int batCount;
    private int mouseCount;

    void Start()
    {
        batCount = 5;
        mouseCount = 5;
    }

    void Update()
    {
        
    }

    public void ActivateText()
    {
        cornerUI.SetActive(true);
    }

    public void ChangeBatCounter()
    {
        batCount--;
        batText.text = "X" + batCount;
    }

    public void ChangeMouseCounter()
    {
        mouseCount--;
        mouseText.text = "X" + mouseCount;
    }
}
