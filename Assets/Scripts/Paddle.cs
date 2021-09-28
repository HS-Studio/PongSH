//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    protected Rigidbody2D PaddleRigidbody;
    protected Vector2 force;
    public Camera MainCamera;
    public Transform PaddlePosition;
    protected DefaultInputActions PaddleMove1;
    protected InputAction PaddleMoveAction1;
    protected DefaultInputActions PaddleMove2;
    protected InputAction PaddleMoveAction2;
    protected Vector2 TouchPosition1;
    protected Vector2 TouchPosition2;
    protected Vector3 TouchPosition1Vector3;
    protected Vector3 TouchPosition2Vector3;
    protected Vector3 TouchWorldPosition1;
    protected Vector3 TouchWorldPosition2;
    protected Vector3 TouchWorldPosition = Vector3.zero;
    void Awake()
    {
        PaddleRigidbody = GetComponent<Rigidbody2D>();

        PaddleMove1 = new DefaultInputActions();
        PaddleMoveAction1 = PaddleMove1.UI.Point1;
        PaddleMoveAction1.Enable();

        PaddleMove2 = new DefaultInputActions();
        PaddleMoveAction2 = PaddleMove2.UI.Point2;
        PaddleMoveAction2.Enable();
    }
    protected Vector3 GetTouchPosition(string player)
    {
        TouchWorldPosition = Vector3.zero;

        TouchPosition1 = PaddleMoveAction1.ReadValue<Vector2>();
        TouchPosition1Vector3 = new Vector3(TouchPosition1.x, TouchPosition1.y, MainCamera.nearClipPlane);
        TouchWorldPosition1 = MainCamera.ScreenToWorldPoint(TouchPosition1Vector3);

        TouchPosition2 = PaddleMoveAction2.ReadValue<Vector2>();
        TouchPosition2Vector3 = new Vector3(TouchPosition2.x, TouchPosition2.y, MainCamera.nearClipPlane);
        TouchWorldPosition2 = MainCamera.ScreenToWorldPoint(TouchPosition2Vector3);

        if(TouchWorldPosition1.y < 0 & player == "Player1")
        {
            TouchWorldPosition.x = TouchWorldPosition1.x;
            return TouchWorldPosition;
        }
        if(TouchWorldPosition2.y < 0 & player == "Player1")
        {
            TouchWorldPosition.x = TouchWorldPosition2.x;
            return TouchWorldPosition;
        }
        if(TouchWorldPosition1.y > 0 & player == "Player2")
        {   
            TouchWorldPosition.x = TouchWorldPosition1.x;
            return TouchWorldPosition;
        }
        if(TouchWorldPosition2.y > 0 & player == "Player2")
        {
            TouchWorldPosition.x = TouchWorldPosition2.x;
            return TouchWorldPosition;
        }
        return Vector3.zero;
    }
}
