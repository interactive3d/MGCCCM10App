using UnityEngine;
using UnityEngine.Events;

public class GestureManager : MonoBehaviour
{
    [Header("Gesture Settings")]
    public float swipeThreshold = 50f; // Minimum distance to consider a swipe
    public int requiredFingerCount = 3; // Minimum fingers required

    [Header("Events")]
    public UnityEvent onSwipeLeft;
    public UnityEvent onSwipeRight;

    private Vector2 startTouchPosition;
    private bool isSwiping = false;

    void Update()
    {
        DetectSwipeGestures();
    }

    private void DetectSwipeGestures()
    {
        if (Input.touchCount >= requiredFingerCount)
        {
            Touch firstTouch = Input.GetTouch(0);

            switch (firstTouch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = firstTouch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        Vector2 currentTouchPosition = firstTouch.position;
                        float swipeDistanceX = currentTouchPosition.x - startTouchPosition.x;

                        if (Mathf.Abs(swipeDistanceX) > swipeThreshold)
                        {
                            if (swipeDistanceX > 0)
                            {
                                TriggerSwipeRight();
                            } else
                            {
                                TriggerSwipeLeft();
                            }
                            isSwiping = false; // Stop detecting for this gesture
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    isSwiping = false;
                    break;
            }
        }
    }

    private void TriggerSwipeLeft()
    {
        Debug.Log("Swipe Left Detected");
        onSwipeLeft?.Invoke();
    }

    private void TriggerSwipeRight()
    {
        Debug.Log("Swipe Right Detected");
        onSwipeRight?.Invoke();
    }
}
