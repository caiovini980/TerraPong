using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script responsible to handle the ball movement
/// </summary>

[
    RequireComponent(typeof(Rigidbody2D)), 
    RequireComponent(typeof(GameObject)),
    RequireComponent(typeof(float))
]
public class BallMovement : MonoBehaviour
{
    [Tooltip("Default speed of the ball")]
    public float speed = 5f;

    [Tooltip("Ball's rigidbody")]
    public Rigidbody2D rb;

    private AudioManager _audioManager; 
    private UIManager _uiManager;
    private Vector3 startPosition = new Vector3(0, 0, 0);
    private Vector2 direction;
    private float maxBoundX = 9f;
    private string P1_Tag = "Player 1";
    private string P2_Tag = "Player 2";
    private string topWall_Tag = "TopWall";
    private string bottomWall_Tag = "BottomWall";
    private string CanvasName = "Canvas";


    void Awake()
    {
        _uiManager = GameObject.Find(CanvasName).GetComponent<UIManager>();
        _audioManager = GetComponent<AudioManager>();
    }

    //Get random direction
    void Start()
    {
        float randomX = Random.Range(0, 2) == 0 ? -1 : 1;
        float randomY = Random.Range(0, 2) == 0 ? -1 : 1;
        direction = new Vector2(randomX, randomY);
    }


    void Update()
    {
        //Moves the ball according to a random direction
        transform.Translate(direction * speed * Time.deltaTime);
        CheckGoal();
    }

    //Check where the ball collides and change it's direction value
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(P1_Tag) || collision.transform.CompareTag(P2_Tag))
        {
            direction.x = -direction.x;
            AddSpeed();
            _audioManager.PlayBallSound();
        }

        if (collision.transform.CompareTag(topWall_Tag) || collision.transform.CompareTag(bottomWall_Tag))
        {
            direction.y = -direction.y;
            _audioManager.PlayBallSound();
        }
    }

    //Launch the ball at the start of the game
    public void Launch()
    {
        float randomX = Random.Range(0, 2) == 0 ? -1 : 1;
        float randomY = Random.Range(0, 2) == 0 ? -1 : 1;
    }

    //Check who scored and reset ball's position
    void CheckGoal()
    {
        if(transform.position.x > maxBoundX)
        {
            _uiManager.UpdateP1Score();
            ResetSpeed();
            transform.position = startPosition;
        }

        else if (transform.position.x < -maxBoundX)
        {
            _uiManager.UpdateP2Score();
            ResetSpeed();
            transform.position = startPosition;
        }
    }

    void AddSpeed()
    {
        speed += 1f;
    }

    void ResetSpeed()
    {
        speed = 5f;
    }
}
