using UnityEngine;

public class DisplayRaycast : MonoBehaviour
{
    public Vector3 myRayOriginVector = new Vector3(0f,0f,0f); // this will store the refernece to the origin position for the ray
    public Vector3 myRayDirectionVector = Vector3.forward; // this will store the reference to the direction

    public GameObject myOriginGameObject; // the reference to the GameObject serving as a start point for the Raycast


    public float myRayDistance; // this will store the lenght of the ray

    public LayerMask layersToInteractWith; // this is a layermask to use with Raycast

    private void Update()
    {
        //Ray myRayObject = new Ray(myOriginGameObject.transform.position, myRayDirectionVector);

        Ray myRayObject = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(myRayObject.origin, myRayObject.direction * myRayDistance, Color.red);

        RaycastHit hitData; // defining variable / object of the type RaycastHit with the name hitData
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(myRayObject, out hitData,myRayDistance, layersToInteractWith) == true)
            {
                Debug.Log("Ray is colliding with " + hitData.collider.name); // this is just to display info in the Console
                SetRandomColorToAnObject(hitData.transform.gameObject);
            }
        }
    }
    

    public void SetRandomColorToAnObject(GameObject objectToConsider)
    {
        objectToConsider.GetComponent<MeshRenderer>().material.color = RandomColorGenerator();
    }

    public Color RandomColorGenerator()
    {
        // this method just returns a Random color
        float randomRValue = Random.Range(0f,1f); 
        float randomGValue = Random.Range(0f,1f); 
        float randomBValue = Random.Range(0f,1f);

        Color myRandomColor = new Color(randomRValue,randomGValue, randomBValue);
        return myRandomColor;
    }
}
