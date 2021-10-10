using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Paddle : Paddle
{
    void FixedUpdate()
    {
        if(countdown.isPaused) return;
        
        GetTouchPosition(1);
        force.x = TouchWorldPosition.x - PaddlePosition.position.x;
        PaddleRigidbody.AddForce(force);
    }
}
