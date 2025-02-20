using System;
using UnityEngine;
using UnityEngine.Events;

public class GestureDetector : MonoBehaviour
{
    // Unity Events for different gestures
    public UnityEvent OnSwipeLeft;
    public UnityEvent OnSwipeRight;
    public UnityEvent OnSwipeUp;
    public UnityEvent OnSwipeDown;
    public UnityEvent OnPinchIn;
    public UnityEvent OnPinchOut;
    public UnityEvent OnPan;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isPinching = false;
    private float initialPinchDistance;

    void Update()
    {
        DetectGestures(); // Continuously check for gestures in each frame
    }

    private void DetectGestures()
    {
        if (Input.touchCount == 1) // Single finger for swipe gestures
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position; // Store initial touch position
            } else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position; // Store end touch position
                DetectSwipe(); // Check for swipe gesture
            }
        } else if (Input.touchCount == 2) // Two fingers for pinch gesture
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (!isPinching && touch0.phase == TouchPhase.Began && touch1.phase == TouchPhase.Began)
            {
                initialPinchDistance = Vector2.Distance(touch0.position, touch1.position); // Store initial pinch distance
                isPinching = true;
            } else if (isPinching && (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved))
            {
                float currentPinchDistance = Vector2.Distance(touch0.position, touch1.position);
                if (currentPinchDistance > initialPinchDistance + 10) // Detect pinch out (zoom in)
                {
                    Debug.Log("Pinch Out detected");
                    OnPinchOut?.Invoke();
                } else if (currentPinchDistance < initialPinchDistance - 10) // Detect pinch in (zoom out)
                {
                    Debug.Log("Pinch In detected");
                    OnPinchIn?.Invoke();
                }
                initialPinchDistance = currentPinchDistance; // Update pinch distance
            } else if (touch0.phase == TouchPhase.Ended || touch1.phase == TouchPhase.Ended)
            {
                isPinching = false; // Reset pinch state when fingers are lifted
            }
        } else if (Input.touchCount == 3) // Three fingers for pan gesture
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Pan detected");
                OnPan?.Invoke(); // Invoke pan event when fingers move
            }
        }
    }

    private void DetectSwipe()
    {
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;
        if (swipeDelta.magnitude > 50) // Check if swipe is long enough to be valid
        {
            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y)) // Determine horizontal or vertical swipe
            {
                if (swipeDelta.x > 0)
                {
                    Debug.Log("Swipe Right detected");
                    OnSwipeRight?.Invoke(); // Swipe right detected
                } else
                {
                    Debug.Log("Swipe Left detected");
                    OnSwipeLeft?.Invoke(); // Swipe left detected
                }
            } else
            {
                if (swipeDelta.y > 0)
                {
                    Debug.Log("Swipe Up detected");
                    OnSwipeUp?.Invoke(); // Swipe up detected
                } else
                {
                    Debug.Log("Swipe Down detected");
                    OnSwipeDown?.Invoke(); // Swipe down detected
                }
            }
        }
    }
}