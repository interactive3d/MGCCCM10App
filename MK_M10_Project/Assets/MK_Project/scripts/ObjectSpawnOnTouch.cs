using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectSpawnOnTouch : MonoBehaviour
{
    public GameObject myPrefabToSpawn; // this will store the reference to the Prefab(model) that will be spawn
    public Camera myCamera; // reference to the camera

    public ARRaycastManager myRaycastManager; // this references the class ARRaycastManager

    private List<ARRaycastHit> myHitList = new List<ARRaycastHit>();

    public List<GameObject> spawnObjectsInTheScene = new List<GameObject>();
    private int spawnObjectNumber = 0;

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch myTouch = Input.GetTouch(0);

            if (myTouch.phase == TouchPhase.Began)
            {
                
                if (myRaycastManager.Raycast(myTouch.position, myHitList, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPointPose = myHitList[0].pose; // I know what Position and Orienation (pose) will be of the spawning point
                    // now I can instantiate the object
                    GameObject newGameObject = Instantiate(myPrefabToSpawn, hitPointPose.position, hitPointPose.rotation);
                    spawnObjectNumber++;
                    newGameObject.name = "Object Number " + spawnObjectNumber;
                    spawnObjectsInTheScene.Add(newGameObject);
                }
            }
            
            // Ray myRay = myCamera.ScreenPointToRay(myTouch.position);
        }
    }

    public void ResetTheScene()
    {
        Debug.Log("Reset the scene");
        if (spawnObjectsInTheScene.Count > 0)
        {
            for (int i = 0; i < spawnObjectsInTheScene.Count; i++)
            {
                Destroy(spawnObjectsInTheScene[i]);
                spawnObjectNumber = 0;
            }
        }
    }

}
