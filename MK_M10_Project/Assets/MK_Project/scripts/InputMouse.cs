using UnityEngine;
using TMPro; // this will allow me to use in the script features / methods of the TextMeshPro


public class InputMouse : MonoBehaviour
{
    // reference to the TMP Text component / element

    [SerializeField]
    private TMP_Text positionText;
    [SerializeField]
    private TMP_Text touchCountLabel;

    private void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 currentMousePosition = Input.mousePosition; // this gets the current position (in pixels) of the mouse coursor
            positionText.text = "X=" + currentMousePosition.x + " Y=" + currentMousePosition.y;
        }
        */
        touchCountLabel.text = "Touches: " + Input.touchCount.ToString();

        // Debug.Log(Input.touchCount);

        if (Input.touchCount>0)
        {
            Debug.Log("Someone is touching me !!!");

            // Input.touchCount
            // Input.touches
            positionText.text = Input.GetTouch(0).position.ToString();

        }

    }

}
