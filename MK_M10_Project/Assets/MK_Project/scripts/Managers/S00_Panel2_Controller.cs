using UnityEngine;
using UnityEngine.SceneManagement;

public class S00_Panel2_Controller : MonoBehaviour
{
    public void ChangeTheScene() {
        SceneManager.LoadScene("S01_LibraryTouch", LoadSceneMode.Single);
    }
}
