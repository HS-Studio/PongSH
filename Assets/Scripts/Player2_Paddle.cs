using UnityEngine;
using UnityEngine.InputSystem;

public class Player2_Paddle : Paddle
{
    // Start is called before the first frame update
    void Start()
    {
        if(settings.SinglePlayer)
        {
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if(countdown.isPaused) return;
        
        GetTouchPosition(2);
        force.x = TouchWorldPosition.x - PaddlePosition.position.x;
        PaddleRigidbody.AddForce(force);
    }
}
