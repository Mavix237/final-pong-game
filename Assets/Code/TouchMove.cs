using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class TouchMove : MonoBehaviour
{
    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    void Update(){
        if(Touch.activeTouches.Count > 0)
        {
            Touch myTouch = Touch.activeTouches[0];

            if (myTouch.phase == TouchPhase.Began || myTouch.phase == TouchPhase.Moved)
            {
                Vector2 newPos = Camera.main.ScreenToWorldPoint(myTouch.screenPosition);
                newPos.y = transform.position.y;
                transform.position = newPos;
            }
        }

    }
}