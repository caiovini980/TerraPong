using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Script responsible the handle the game's rules
/// </summary>

public class GameManager : MonoBehaviour
{
    [Tooltip("Object responsible for the game's UI")]
    public UIManager uiManager;

    [Tooltip("Panel to receive the player 1's input")]
    public GameObject p1InstructionsPanel;

    [Tooltip("Panel to receive the player 2's input")]
    public GameObject p2InstructionsPanel;

    [Tooltip("Main menu panel")]
    public GameObject mainPanel;

    [Tooltip("Player 1's input")]
    public InputField p1InputField;

    [Tooltip("Player 2's input")]
    public InputField p2InputField;

    private int p1Wins = 0;
    private int p2Wins = 0;

    private bool _isPaused = false;

    void Update()
    {
        GetPauseInput();
        GetWinner();
    }

    //Check if the game is being paused 
    void GetPauseInput()
    {
        if (SceneManager.sceneCount == 1 && Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    //check who wins and save it's scores
    void GetWinner()
    {
        if (uiManager)
        {
            if (uiManager._p1Score == 10)
            {
                int wins = PlayerPrefs.GetInt("p1wins");
                p1Wins = wins;
                p1Wins++;
                PlayerPrefs.SetInt("p1wins", p1Wins);
                PlayerPrefs.Save();
                Scoreboard();
            }

            if (uiManager._p2Score == 10)
            {
                int wins = PlayerPrefs.GetInt("p2wins");
                p2Wins = wins;
                p2Wins++;
                PlayerPrefs.SetInt("p2wins", p2Wins);
                PlayerPrefs.Save();
                Scoreboard();
            }
        }
        else
        {
            return;
        }
        
    }

    //load the scoreboard scene
    void Scoreboard()
    {
        SceneManager.LoadScene(2);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _isPaused = false;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ActivateP1InstructionsPanel()
    {
        mainPanel.SetActive(false);
        p1InstructionsPanel.SetActive(true);
        p2InstructionsPanel.SetActive(false);
    }

    public void ActivateP2InstructionsPanel()
    {
        mainPanel.SetActive(false);
        p1InstructionsPanel.SetActive(false);
        p2InstructionsPanel.SetActive(true);
    }

    public void SaveInputs()
    {
        PlayerPrefs.SetString("p1name", p1InputField.text);
        PlayerPrefs.SetString("p2name", p2InputField.text);
        PlayerPrefs.Save();
    }

}
