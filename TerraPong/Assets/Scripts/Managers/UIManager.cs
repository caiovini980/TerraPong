using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script responsible to handle the UI in-game
/// </summary>

[RequireComponent(typeof(Text))]
public class UIManager : MonoBehaviour
{
    [Tooltip("Score texts")]
    public Text player1Score, player2Score;
    public int _p1Score, _p2Score;

    // Start is called before the first frame update
    void Start()
    {
        player1Score.text = "" + 0;
        player2Score.text = "" + 0;
    }

    public void UpdateP1Score()
    {
        _p1Score++;
        player1Score.text = "" + _p1Score.ToString();
    }

    public void UpdateP2Score()
    {
        _p2Score++;
        player2Score.text = "" + _p2Score.ToString();
    }
}
