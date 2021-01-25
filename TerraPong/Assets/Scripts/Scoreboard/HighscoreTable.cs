using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script responsible for the Scoreboard behaviour
/// </summary>

[RequireComponent(typeof(Text))]
public class HighscoreTable : MonoBehaviour
{
    [Tooltip("Name on the first row")]
    public Text row1Name;

    [Tooltip("Name on the second row")]
    public Text row2Name;
    
    [Tooltip("Score on the first row")]
    public Text row1Wins;

    [Tooltip("Score on the second row")]
    public Text row2Wins;

    private GameManager _gameManager;

    private string _p1Name_Token = "p1name";
    private string _p2Name_Token = "p2name";
    private string _p1Wins_Token = "p1wins";
    private string _p2Wins_Token = "p2wins";
    private string _gameManagerName = "GameManager";

    void Awake()
    {
        _gameManager = GameObject.Find(_gameManagerName).GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        string p1name = PlayerPrefs.GetString(_p1Name_Token);
        string p2name = PlayerPrefs.GetString(_p2Name_Token);
        int p1wins = PlayerPrefs.GetInt(_p1Wins_Token);
        int p2wins = PlayerPrefs.GetInt(_p2Wins_Token);

        if (string.IsNullOrEmpty(p1name))
        {
            p1name = "Player 1";
        }

        if (string.IsNullOrEmpty(p2name))
        {
            p2name = "Player 2";
        }

        if (p1wins > p2wins)
        {
            row1Name.text = p1name;
            row1Wins.text = p1wins.ToString();
            row2Name.text = p2name;
            row2Wins.text = p2wins.ToString();
        }

        else
        {
            row1Name.text = p2name;
            row1Wins.text = p2wins.ToString();
            row2Name.text = p1name;
            row2Wins.text = p1wins.ToString();
        }
    }
}
