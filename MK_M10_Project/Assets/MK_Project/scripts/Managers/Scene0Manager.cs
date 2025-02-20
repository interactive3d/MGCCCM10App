using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class Scene0Manager : MonoBehaviour {
    [System.Serializable]
    public class PanelEvents {
        public UnityEvent onPanelStart; // Event triggered when panel is shown
        public UnityEvent onPanelEnd;   // Event triggered when panel is hidden
    }

    public List<GameObject> uiPanels;  // List of UI panels
    public List<PanelEvents> panelEvents; // List of panel-specific events
    public float switchTime = 5f;      // Time before switching to the next panel (set in Inspector)
    private int currentPanelIndex = 0;
    private bool autoSwitchEnabled = true;

    void Start() {
        if (uiPanels == null || uiPanels.Count == 0) {
            Debug.LogError("No UI panels assigned in the Inspector!");
            return;
        }

        if (panelEvents.Count != uiPanels.Count) {
            Debug.LogWarning("The number of panel events does not match the number of panels!");
        }

        // Enable the first panel and disable the rest
        for (int i = 0; i < uiPanels.Count; i++) {
            uiPanels[i].SetActive(i == 0);
        }

        // Trigger the start event for the first panel
        if (panelEvents.Count > 0 && panelEvents[0].onPanelStart != null) {
            panelEvents[0].onPanelStart.Invoke();
        }

        // Start automatic panel switch if enabled
        if (autoSwitchEnabled && switchTime > 0) {
            StartCoroutine(SwitchToNextPanelAfterDelay(switchTime));
        }
    }

    // Coroutine to switch to the next panel after a delay
    private IEnumerator SwitchToNextPanelAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        ShowNextPanel();
    }

    // Function to manually switch to the next panel
    public void ShowNextPanel() {
        if (currentPanelIndex < uiPanels.Count - 1) {
            // Trigger panel end event for the current panel
            if (panelEvents.Count > currentPanelIndex && panelEvents[currentPanelIndex].onPanelEnd != null) {
                panelEvents[currentPanelIndex].onPanelEnd.Invoke();
            }

            // Disable current panel and enable the next one
            uiPanels[currentPanelIndex].SetActive(false);
            currentPanelIndex++;
            uiPanels[currentPanelIndex].SetActive(true);

            // Trigger panel start event for the new panel
            if (panelEvents.Count > currentPanelIndex && panelEvents[currentPanelIndex].onPanelStart != null) {
                panelEvents[currentPanelIndex].onPanelStart.Invoke();
            }
        } else {
            Debug.Log("No more panels to show.");
        }
    }

    // Function to disable automatic switching
    public void DisableAutoSwitch() {
        autoSwitchEnabled = false;
        StopAllCoroutines();
    }
}
