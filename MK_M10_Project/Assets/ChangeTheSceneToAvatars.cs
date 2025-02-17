using UnityEngine;
using UnityEngine.SceneManagement; // this namespace is required to change the scenes

public class ChangeTheSceneToAvatars : MonoBehaviour
{
    public void ChangeTheSceneNow()
    {
        SceneManager.LoadScene("S01_LibraryTouch"); // this will trigger the scene to be open called: "S01_LibraryTouch"
    }


}
