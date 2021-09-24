using UnityEngine;

public class BorderCollider: MonoBehaviour 
{
    private EdgeCollider2D _edgeCollider2D;
    private Rigidbody2D _rigidbody2D;
    private Canvas _canvas;
    private float y, x;
    private Vector2 _topLeft, _topRight, _bottomLeft, _bottomRight;

    private void Start()
    {
        //Adding Edge Collider
        _edgeCollider2D = gameObject.GetComponent<EdgeCollider2D>();
        
        //Adding Rigid body as a kinematic for collision detection
        //_rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        //_rigidbody2D.bodyType = RigidbodyType2D.Static;
        //_rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        
        //Assigning canvas
        _canvas = GetComponent<Canvas>();
        
        GetCanvasDimension(); // Finds height and width fo the canvas
        GetCornerCoordinate(); // Finds co-ordinate of the corners as a Vector2
        DrawCollider(); // Draws Edge collide around the corners of canvas
    }

    public void GetCornerCoordinate()
    {
        // Assign corners coordinate in the variables
        
        _topLeft = new Vector2(-x,y); // Top Left Corner
        _topRight = new Vector2(x,y); // Top Right Corner
        _bottomLeft = new Vector2(-x,-y); // Bottom Left Corner
        _bottomRight = new Vector2(x,-y); // Bottom Right Corner
    }

    void GetCanvasDimension()
    {
        y = (_canvas.GetComponent<RectTransform>().rect.height) / 2;
        x = (_canvas.GetComponent<RectTransform>().rect.width) / 2;
    }

    void DrawCollider()
    {
        _edgeCollider2D.points = new[] {_topLeft, _topRight, _bottomRight, _bottomLeft,_topLeft};
    }

}