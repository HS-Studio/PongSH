//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScore : MonoBehaviour
{   
    public Rigidbody2D BallRigidbody, Player1Paddel, Player2Paddel, CPU_Paddle;
    public EdgeCollider2D ScreenBounds;
    int Player1Score, Player2Score;
    public Text Player1ScoreText, Player2ScoreText, WonText, WonText2Player;
    public Button ButtonToMenu;
    Vector2 force;
    int SpeedForce = 3;
    AudioSource _audioSource;
    public AudioClip PaddleHit, WallHit, Miss;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        ResetBall();
        WonText.gameObject.SetActive(false);
        WonText2Player.gameObject.SetActive(false);
        ButtonToMenu.gameObject.SetActive(false);
    }
    
    void PlaySound(string clip)
    {
        //_audioSource = GetComponent<AudioSource>();
        switch (clip)
        {
            case "paddle_pong":
                _audioSource.clip = PaddleHit;
                _audioSource.Play();
                break;
            case "wall_pong":
                _audioSource.clip = WallHit;
                _audioSource.Play();
                break;
            case "miss_pong":
                _audioSource.clip = Miss;
                _audioSource.Play();
                break;
        }
    }
    
    void ResetBall()
    {   
        BallRigidbody.velocity = Vector2.zero;
        BallRigidbody.position = Vector2.zero;
        force.y = Random.value < 0.5f ? -1.0f : 1.0f;
        force.x = Random.value < 0.5f ? -1.0f : 1.0f;
        BallRigidbody.AddForce( force * SpeedForce );
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Player1Paddel.velocity.x);
    }

    private void Win()
    {
        if(PongConfig.SinglePlayer)
        {
            if(Player1Score == 10)
            {   
                WonText.text = "Sie haben gewonnen!";
                WonText.gameObject.SetActive(true);
                GameEnd();
            }
            if(Player2Score == 10)
            {   
                WonText.text = "Sie haben verloren!";
                WonText.gameObject.SetActive(true);
                GameEnd();
            }
        }
        else
        {
            if(Player1Score == 10)
            {   
                WonText2Player.text = "Spieler 1 hat gewonnen!";
                WonText2Player.gameObject.SetActive(true);
                GameEnd();
            }
            if(Player2Score == 10)
            {   
                WonText2Player.text = "Spieler 2 hat gewonnen!";
                WonText2Player.gameObject.SetActive(true);
                GameEnd();
            }
        }

    }
    private void GameEnd()
    {
        BallRigidbody.position = Vector2.zero;
        BallRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        ButtonToMenu.gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if( other.gameObject.tag == "Player" )
        {
            PlaySound("paddle_pong");
            force.x = (BallRigidbody.position.x - Player1Paddel.position.x) + ( Player1Paddel.velocity.x * 0.1f );
            force.y = Random.Range(0.25f, 1.0f);
            BallRigidbody.AddForce( force );
            //Debug.Log(force);
        }
        if( other.gameObject.tag == "Player2" )
        {
            PlaySound("paddle_pong");
            force.x = (BallRigidbody.position.x - Player2Paddel.position.x) + ( Player2Paddel.velocity.x * 0.1f );
            force.y = Random.Range(-1.0f, 0.25f);
            BallRigidbody.AddForce( force );
            //Debug.Log(force);
        }
        if( other.gameObject.tag == "CPU" )
        {
            PlaySound("paddle_pong");
            force.x = (BallRigidbody.position.x - CPU_Paddle.position.x) + ( CPU_Paddle.velocity.x * 0.1f );
            force.y = Random.Range(-1.0f, 0.25f);
            BallRigidbody.AddForce( force );
            //Debug.Log(force);
        }
        if( other.gameObject.tag == "bounds" )
        {   

            ContactPoint2D contact = other.GetContact(0);

            if(Mathf.Round(contact.point.y) >= Mathf.Round(ScreenBounds.bounds.max.y) -1)
            {
                PlaySound("miss_pong");
                ResetBall();
                Player1Score++;
                Player1ScoreText.text = Player1Score.ToString();
                Win();
                //Debug.Log("Player 1 get a Point");
            }
            else if(Mathf.Round(-contact.point.y) >= Mathf.Round(ScreenBounds.bounds.max.y) -1)
            {
                PlaySound("miss_pong");
                ResetBall();
                Player2Score++;
                Player2ScoreText.text = Player2Score.ToString();
                Win();
                //Debug.Log("Player 2 get a Point");
            }
            else
            {
                PlaySound("wall_pong");
            }
        }
    }
}
