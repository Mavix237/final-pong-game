using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;


public class BallTest : MonoBehaviour
{
    int speed = 10;
    public Rigidbody2D ballRB;
    public CustomCollider2D banana;
    void Awake()
    {
        InputSystem.EnableDevice(Accelerometer.current);
        EnhancedTouchSupport.Enable();
    }


    void FixedUpdate()
    {
        Vector2 accel = Accelerometer.current.acceleration.ReadValue();
        ballRB.AddForce(accel * speed);
    }

    void Update()
    {
        // see if there's a touch
        if(Touch.activeTouches.Count > 0)
        {
            Touch myTouch = Touch.activeTouches[0];
            // when your finger moves
            if (myTouch.phase == TouchPhase.Moved)
            {
                ballRB.AddForce(myTouch.delta);
            
            }
        }
        void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Brick")){
            Destroy(other.gameObject);
            
        }
    }
}
}
