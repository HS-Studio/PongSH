using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Paddle : Paddle
{
    void Start()
    {

    }
    void Update()
    {
        GetTouchPosition("Player1");
        force.x = TouchWorldPosition.x - PaddlePosition.position.x;
        PaddleRigidbody.AddForce(force);
    }
    void FixedUpdate()
    {

    }
}
