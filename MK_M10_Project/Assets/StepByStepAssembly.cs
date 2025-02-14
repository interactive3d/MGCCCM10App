using UnityEngine;
using System.Collections.Generic;

public class StepByStepAssembly : MonoBehaviour
{
    [System.Serializable]
    public class AssemblyStep
    {
        public string stepName; // Optional, for debugging
        public List<GameObject> partsToShow = new List<GameObject>(); // Objects to reveal in this step
    }

    [SerializeField] private GameObject rootObject; // Root object with all assembly parts
    [SerializeField] private List<AssemblyStep> steps = new List<AssemblyStep>(); // List of steps
    private int currentStep = -1; // Step index (-1 means no step is active)

    [Header("Inspector Controls")]
    public bool goToNext = false;
    public bool goToPrevious = false;

    void Start()
    {
        InitializeSteps();
        GoToStep(0); // Start at step 0
    }

    void Update()
    {
        // Check if the boolean flags have been triggered in the Inspector
        if (goToNext)
        {
            goToNext = false;
            NextStep();
        }
        if (goToPrevious)
        {
            goToPrevious = false;
            PreviousStep();
        }
    }

    void InitializeSteps()
    {
        if (rootObject == null)
        {
            Debug.LogError("Root Object is not assigned!");
            return;
        }

        // Hide all parts initially
        foreach (Transform child in rootObject.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void NextStep()
    {
        if (currentStep < steps.Count - 1)
        {
            GoToStep(currentStep + 1);
        } else
        {
            Debug.Log("Already at the last step.");
        }
    }

    public void PreviousStep()
    {
        if (currentStep > 0)
        {
            GoToStep(currentStep - 1);
        } else
        {
            Debug.Log("Already at the first step.");
        }
    }

    public void GoToStep(int stepId)
    {
        if (stepId < 0 || stepId >= steps.Count)
        {
            Debug.LogError("Invalid step ID.");
            return;
        }

        // Show new parts for this step (previous step parts remain visible)
        foreach (GameObject part in steps[stepId].partsToShow)
        {
            if (part != null)
            {
                SetActiveWithChildren(part, true);
            }
        }

        currentStep = stepId;
        Debug.Log($"Switched to Step {stepId}: {steps[stepId].stepName}");
    }

    private void SetActiveWithChildren(GameObject obj, bool isActive)
    {
        obj.SetActive(isActive);
        foreach (Transform child in obj.transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }
}
