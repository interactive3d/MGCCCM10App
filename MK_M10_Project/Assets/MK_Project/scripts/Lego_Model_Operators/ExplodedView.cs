using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodedView : MonoBehaviour
{
    public GameObject rootObject; // Reference to the root GameObject
    public float explodeDuration = 5f; // Total time for the explosion
    public float explodeDistanceMultiplier = 1.5f; // How far the parts move outward
    public bool triggerAnimation = false; // Public bool to trigger animation
    public Vector3 restrictedDirection = Vector3.down; // Direction to restrict disassembly

    private Dictionary<Transform, Vector3> originalPositions = new Dictionary<Transform, Vector3>();
    private Dictionary<Transform, Vector3> targetPositions = new Dictionary<Transform, Vector3>();
    private bool isExploded = false;
    private bool isAnimating = false;

    void Start()
    {
        if (rootObject == null) rootObject = gameObject;
        CalculateExplosionPositions();
    }

    void Update()
    {
        if (triggerAnimation)
        {
            triggerAnimation = false;
            ToggleExplode();
        }
    }

    void CalculateExplosionPositions()
    {
        originalPositions.Clear();
        targetPositions.Clear();
        Bounds combinedBounds = new Bounds(rootObject.transform.position, Vector3.zero);

        foreach (Transform child in rootObject.transform)
        {
            if (child.gameObject.activeSelf)
            {
                Renderer rend = child.GetComponent<Renderer>();
                if (rend)
                {
                    combinedBounds.Encapsulate(rend.bounds);
                }
            }
        }

        Vector3 center = combinedBounds.center;

        foreach (Transform child in rootObject.transform)
        {
            if (child.gameObject.activeSelf)
            {
                Renderer rend = child.GetComponent<Renderer>();
                if (rend)
                {
                    Bounds bounds = rend.bounds;
                    Vector3 direction = (bounds.center - center).normalized;

                    // Restrict movement in the given direction
                    direction = Vector3.ProjectOnPlane(direction, restrictedDirection).normalized;

                    Vector3 moveDistance = direction * bounds.extents.magnitude * explodeDistanceMultiplier;

                    originalPositions[child] = child.position;
                    targetPositions[child] = child.position + moveDistance;
                }
            }
        }
    }

    public void ToggleExplode()
    {
        if (!isAnimating)
        {
            StartCoroutine(AnimateExplosion(isExploded ? false : true));
        }
    }

    private IEnumerator AnimateExplosion(bool explode)
    {
        isAnimating = true;
        float elapsedTime = 0f;

        while (elapsedTime < explodeDuration)
        {
            float progress = elapsedTime / explodeDuration;
            foreach (var entry in originalPositions)
            {
                Transform child = entry.Key;
                Vector3 start = explode ? entry.Value : targetPositions[child];
                Vector3 end = explode ? targetPositions[child] : entry.Value;
                child.position = Vector3.Lerp(start, end, progress);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        foreach (var entry in originalPositions)
        {
            entry.Key.position = explode ? targetPositions[entry.Key] : entry.Value;
        }

        isExploded = explode;
        isAnimating = false;
    }
}
