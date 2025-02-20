using UnityEngine;

public class ControlTheAPp : MonoBehaviour
{
    public void CloseTheApp()
    {
        Debug.Log("The app should closed");
    #if UNITY_EDITOR
        // For the Unity editor, stop playing the game (editor play mode)
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
       
        Application.Quit();
        Debug.Log("The app should closed - for sure");
    }
}
