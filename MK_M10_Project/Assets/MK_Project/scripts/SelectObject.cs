using UnityEngine;

public class SelectObject : MonoBehaviour
{
    [SerializeField]
    private Transform rayOrigin;

    [SerializeField]
    private Vector3 rayOriginPos;
    
    [SerializeField]
    private Vector3 rayDirection;
    
    [SerializeField]
    private float rayDistance;


    private void Update()
    {
        rayOriginPos = rayOrigin.position;
        rayDirection = Vector3.forward; // this is vector [0,0,1] so the Z
        
        RaycastHit hit; // this is a variable that will store the output from the raycast hits
        Ray sampleRay = new Ray(rayOriginPos, rayDirection);

        Debug.DrawRay(rayOriginPos, rayDirection * 10,Color.red);

        if (Physics.Raycast(sampleRay, out hit))
        {
            Debug.Log("I am hitting" + hit.transform.name);
        }
    }
}
