using UnityEngine;

public class RandomColorObject : MonoBehaviour
{
    [SerializeField] // this will make it exposed / visible in the inspector
    private GameObject myObject; // this will be a reference to the GameObject that I will apply the random color

    [SerializeField]
    private Color myRandomColor; // this will store the random color that will be applied to the object


    public void GenerateRandomColor()
    {
        // purpose of this public function/method is to generate the random color

        float redValue = Random.Range(0f, 1f); // this will get random value between 0 and 1 as float type data
        float greenValue = Random.Range(0f, 1f);
        float blueValue = Random.Range(0f, 1f);

        myRandomColor = new Color(redValue, greenValue, blueValue);
    }

    private void Start()
    {
        if (myObject == null)
        {
            myObject = gameObject;
        }
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0)==true)
        {
            
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("User pressed mouse button");
        GenerateRandomColor();

        // access the object (cube or other)
        // access its MeshRenderer
        // In MeshRenderer access its Materials
        // In the Material access the Color
        // Apply new value of the Color that will be the myRandomColor
        myObject.GetComponent<MeshRenderer>().material.color = myRandomColor;
    }
}
