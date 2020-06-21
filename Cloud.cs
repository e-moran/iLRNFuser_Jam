using System;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float movementPeriod = 1f;
    public float yTravel = 0.05f; // The range up and down the cloud moves as it bobs
    
    private float _topY;
    private float _bottomY;

    // Start is called before the first frame update
    void Start()
    {
        Collider2D collider = GetComponent<PolygonCollider2D>();
        do
        {
            
        } while (Physics2D.IsTouchingLayers(collider));
        
        _topY = transform.position.y + yTravel;
        _bottomY = transform.position.y - yTravel;
    }
    
    void Update()
    {
        MovementDirection direction = (int) Math.Floor(Time.time / movementPeriod) % 2 == 0 // Flip between the two y-directions every time we pass the period
            ? MovementDirection.Down
            : MovementDirection.Up;

        Vector3 startPos = new Vector3(transform.position.x, direction == MovementDirection.Up ? _bottomY : _topY, 0);
        Vector3 endPos = new Vector3(transform.position.x, direction == MovementDirection.Up ? _topY : _bottomY, 0);

        float lerpFactor = Time.time % movementPeriod;

        transform.position = Vector3.Lerp(startPos, endPos, lerpFactor);
    }

    enum MovementDirection
    {
        Up,
        Down
    }
}
