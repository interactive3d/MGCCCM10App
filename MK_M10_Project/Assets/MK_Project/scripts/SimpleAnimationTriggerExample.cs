using UnityEngine;

public class SimpleAnimationTriggerExample : MonoBehaviour
{
    public Animator myReferenceToAnimator;

    public AnimationClip myAnimationClip; // refernece to an animation clip

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // now the animation will start to transition to clip #2
            Debug.Log("The A key was pressed");

            // get access to the component Animator
            // myReferenceToAnimator.SetTrigger("Start2ndAnim"); // triggers the animation transition
            myReferenceToAnimator.Play(myAnimationClip.name);
        }
    }
}
