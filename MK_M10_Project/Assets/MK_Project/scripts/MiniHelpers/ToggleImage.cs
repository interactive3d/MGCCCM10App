using UnityEngine;
using UnityEngine.UI;

public class ToggleImage : MonoBehaviour {
    public Sprite imageOn;  // Assign the "on" image in the Inspector
    public Sprite imageOff; // Assign the "off" image in the Inspector

    private Image uiImage;
    private bool isToggled = false;

    void Start() {
        uiImage = GetComponent<Image>();

        // Ensure an image is assigned to avoid null references
        if (uiImage == null) {
            Debug.LogError("No Image component found on this GameObject.");
            return;
        }

        // Set initial sprite
        uiImage.sprite = imageOff;
    }

    public void Toggle() {
        isToggled = !isToggled;
        uiImage.sprite = isToggled ? imageOn : imageOff;
    }
}
