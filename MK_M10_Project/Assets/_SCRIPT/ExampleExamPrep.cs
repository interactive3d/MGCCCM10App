using UnityEngine;

public class ExampleExamPrep : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(AddTwoNumber(50.1f, 10.1f, 10.2f));
        Debug.Log(AddTwoNumber(5, 66, 10));

    }


    private int AddTwoNumber()
    {
        return 0;
    }
    int numberA = 0;
    private int AddTwoNumber(int numberA)
    {
        return numberA;
    }
    private int AddTwoNumber(int numberA, int numberB)
    {
        /// WHATERVER HAPPENDS HERE
        int result = numberA + numberB;
        return result; 
    }
    
    private int AddTwoNumber(int numberA, int numberB, int numberC)
    {
        
        return (numberA + numberB + numberC);
    }
    private float AddTwoNumber(float numberA, float numberB, float numberC)
    {
        return (numberA + numberB + numberC);
    }
}
