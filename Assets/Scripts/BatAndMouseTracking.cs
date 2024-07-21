using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatAndMouseTracking : MonoBehaviour
{
    public GameObject star;
    public TextMeshProUGUI titleText;

    public GameObject cornerUI;
    public TextMeshProUGUI batText;
    public TextMeshProUGUI mouseText;
    private int batCount;
    private int mouseCount;

    void Start()
    {
        batCount = 5;
        mouseCount = 5;
        
        if (PlayerPrefs.GetInt("Star") == 1)
        {
            star.SetActive(true);
            titleText.text = "The\nTRUE";
        }
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

    public bool CheckWinCondition()
    {
        if (mouseCount == 0 && batCount == 0)
        {
            PlayerPrefs.SetInt("Star", 1);
            return true;
        }

        return false;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }
}
