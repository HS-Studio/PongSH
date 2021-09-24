using UnityEngine;
using UnityEngine.InputSystem;

public class Player2_Paddle : Paddle
{
    // Start is called before the first frame update
    void Start()
    {
        if(PongConfig.SinglePlayer)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetTouchPosition("Player2");
        force.x = TouchWorldPosition.x - PaddlePosition.position.x;
        PaddleRigidbody.AddForce(force);
    }
}
