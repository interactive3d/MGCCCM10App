using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.IO;
using System.Collections;

public class VideoPlayerController : MonoBehaviour {
    public RawImage videoDisplay;  // UI RawImage for displaying the video
    public VideoPlayer videoPlayer; // Video Player component
    public Button uiButton; // Reference to the UI button
    public string videoFileName = "mgccc_gobig.mp4"; // MP4 file name

    private string videoPath;

    void Start() {
        // Ensure the button is initially hidden
        if (uiButton != null) {
            uiButton.gameObject.SetActive(false);
        }

        // Construct the full path to the SharedResource folder
        videoPath = Path.Combine(Application.streamingAssetsPath, videoFileName);

        // Check if file exists
        if (!File.Exists(videoPath)) {
            Debug.LogError("Video file not found: " + videoPath);
            return;
        }

        // Configure Video Player
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = videoPath;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.isLooping = false;  // Set to true if you want looping
        videoPlayer.Prepare();
    }

    // Play the video and start coroutine
    public void PlayVideo() {
        if (videoPlayer.isPrepared) {
            videoPlayer.Play();
            StartCoroutine(ShowButtonAfterDelay(5f)); // Start coroutine
        } else {
            Debug.LogError("Video is not prepared yet!");
        }
    }

    // Stop the video
    public void StopVideo() {
        if (videoPlayer.isPlaying) {
            videoPlayer.Stop();
        }
    }

    // Coroutine to show the button after 5 seconds
    private IEnumerator ShowButtonAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);

        if (uiButton != null) {
            uiButton.gameObject.SetActive(true);
        }
    }
}
