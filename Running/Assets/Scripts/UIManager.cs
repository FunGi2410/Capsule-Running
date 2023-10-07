using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameoverPanel;
    public GameObject startPanel;
    public GameObject showScoreText;

    public void SetScoreText (string txt)
    {
        if (scoreText)
        {
            scoreText.text = txt;
        }
    }

    public void ShowGameoverPanel(bool isShow)
    {
        if (gameoverPanel)
        {
            gameoverPanel.SetActive(isShow);
        }
    }

    private bool myIsShow;
    public void SetIsShow(bool state)
    {
        myIsShow = state;
    }

    public bool GetIsShow()
    {
        return myIsShow;
    }
    public void ShowStartPanel()
    {
        if (startPanel)
        {
            startPanel.SetActive(myIsShow);
            showScoreText.SetActive(!myIsShow);
        }
    }

    public void ShowScoreText()
    {
        if (showScoreText)
        {
            showScoreText.SetActive(true);
        }
    }
}
