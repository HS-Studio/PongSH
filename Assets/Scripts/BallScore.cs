using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallScore : MonoBehaviour
{   
    [SerializeField]
    private Rigidbody2D BallRigidbody, Player1Paddel, Player2Paddel, CPU_Paddle;
    [SerializeField]
    private EdgeCollider2D ScreenBounds;
    int Player1Score, Player2Score;
    [SerializeField]
    private Text Player1ScoreText, Player2ScoreText, WonText, WonText2Player, WonText2Player2, CountdownText;
    [SerializeField]
    private Button ButtonToMenu;
    private Vector2 force;
    int SpeedForce = 3;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip PaddleHit, WallHit, Miss;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        // ResetBall();
        WonText.gameObject.SetActive(false);
        WonText2Player.gameObject.SetActive(false);
        WonText2Player2.gameObject.SetActive(false);
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
    
    public void ResetBall()
    {   
        BallRigidbody.velocity = Vector2.zero;
        BallRigidbody.position = Vector2.zero;
        force.y = Random.value < 0.5f ? -1.0f : 1.0f;
        force.x = Random.value < 0.5f ? -1.0f : 1.0f;
        BallRigidbody.AddForce( force * SpeedForce );
    }

    private void Win()
    {
        if(settings.SinglePlayer)
        {
            if(Player1Score == 10)
            {   
                WonText.text = "Gewonnen!";
                show1PlayerText();
                GameEnd();
            }
            if(Player2Score == 10)
            {   
                WonText.text = "Leider verloren.";
                show1PlayerText();
                GameEnd();
            }
        }
        else
        {
            if(Player1Score == 10)
            {   
                WonText2Player.text = "Gewonnen!";
                WonText2Player2.text = "Verloren.";
                show2PlayerText();
                GameEnd();
            }
            if(Player2Score == 10)
            {   
                WonText2Player.text = "Verloren.";
                WonText2Player2.text = "Gewonnen!";
                show2PlayerText();
                GameEnd();
            }
        }

    }
    void show1PlayerText()
    {
        WonText.gameObject.SetActive(true);
    }
    void show2PlayerText()
    {
        WonText2Player.gameObject.SetActive(true);
        WonText2Player2.gameObject.SetActive(true);
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
