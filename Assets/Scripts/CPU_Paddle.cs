//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CPU_Paddle : Paddle
{
    float Difficulty;
    public Rigidbody2D Ball;
    //static bool SinglePlayer;

    // Start is called before the first frame update
    void Start()
    {
        if(!settings.SinglePlayer)
        {
            gameObject.SetActive(false);
        }
        Difficulty = settings.DifficultyLevel * 0.1f;
        //Debug.Log(settings.DifficultyLevel);
    }

    void FixedUpdate()
    {
        if(countdown.isPaused) return;
        
        if(Ball.position.y > 0)
        {
            if( Ball.velocity.y > 0.0f)
            {
                force.x = ( Ball.position.x - PaddlePosition.position.x ) * Difficulty;
            }
            else if(PaddlePosition.position.x > 0.0f || PaddlePosition.position.x < 0.0f )
            {
                force.x = ( PaddlePosition.position.x *-1 ) * Difficulty;
            }
            PaddleRigidbody.AddForce( force );
        }
    }
}
