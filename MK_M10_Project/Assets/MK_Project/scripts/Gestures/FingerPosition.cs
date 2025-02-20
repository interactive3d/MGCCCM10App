using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FingerPosition : MonoBehaviour
{
    public TMP_Text fingerIDLabel; // this is label that will display the ID of the finger
    public int myFingerNumber; // this is my number for the image / finger

    public TMP_Text gestureInfoLabel; // this is label that display text what gesture is been recognized.
    
    private Vector2 touchStartPos; // to store initial touch position
    private float swipeThreshold = 50f; // minimum distance to be considered a swipe

    private void Update()
    {
        if (Input.touchCount > myFingerNumber)
        {

            Touch touch = Input.GetTouch(myFingerNumber);

            gameObject.transform.position = touch.position;
            fingerIDLabel.text = touch.fingerId.ToString();
            
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    // I will change the color to color 1
                    gameObject.GetComponent<Image>().color = new Color(1f,0f,0f);
                    touchStartPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    // I will change the color to color 2
                    // ApplyRandomColor();
                    gameObject.GetComponent<Image>().color = new Color(0f, 1f, 0f);
                    break;
                case TouchPhase.Stationary:
                    // I will change the color to color 3
                    // ApplyRandomColor();
                    gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
                    break;
                case TouchPhase.Ended:
                    // I will change the color to color 4
                    gameObject.GetComponent<Image>().color = new Color(0f, 0f, 1f);
                    // ApplyRandomColor();
                    DetectSwipe(touch);
                    break;
            }

        }
    }

    public void ApplyRandomColor()
    {
        gameObject.GetComponent<Image>().color = Random.ColorHSV();
    }


    private void DetectSwipe(Touch touch)
    {
        // Calculate the distance between start and end positions
        float swipeDistance = touch.position.x - touchStartPos.x;

        if (Mathf.Abs(swipeDistance) > swipeThreshold) // Check if swipe is long enough
        {
            if (swipeDistance > 0)
            {
                // Swipe right
                gestureInfoLabel.text = "Swipe Right!";
            } else
            {
                // Swipe left
                gestureInfoLabel.text = "Swipe Left!";
            }
        }
    }

}
