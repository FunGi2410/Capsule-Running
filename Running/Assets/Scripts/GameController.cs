using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private float myScore;
    private bool isGameover;
    private UIManager myUI;


    private void Start()
    {
        myUI = FindObjectOfType<UIManager>();
    }
    void Update()
    {
        if (myUI.GetIsShow())
        {
            myUI.ShowStartPanel();
        }
        else
        {
            myUI.ShowStartPanel();
            myUI.ShowScoreText();
        }

        //----------------------------------------//
        if (isGameover)
        {
            myUI.ShowGameoverPanel(true);
            return;
        }
    }

    // các hàm truy xuất điểm
    public void SetScore(float value)
    {
        myScore = value;
    }

    public float GetScore()
    {
        return myScore;
    }

    public void ScoreIncrement()
    {
        myScore++;
        myUI.SetScoreText("" + myScore);
    }

    // các hàm truy xuất game over
    public void SetGameover(bool state)
    {
        isGameover = state;
    }

    public bool GetGameover()
    {
        return isGameover;
    }

    public void Replay()
    {
        SceneManager.LoadScene("MainScene");
    }
}


