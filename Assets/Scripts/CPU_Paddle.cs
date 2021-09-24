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
        if(PongConfig.SinglePlayer == false)
        {
            gameObject.SetActive(false);
        }
        Difficulty = PongConfig.DifficultyLevel * 0.1f;
        //Debug.Log(PongConfig.DifficultyLevel);
    }

    // Update is called once per frame
    void Update()
    {   
    }
    void FixedUpdate()
    {
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
