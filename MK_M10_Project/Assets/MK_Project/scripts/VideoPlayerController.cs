using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.IO;

public class VideoPlayerController : MonoBehaviour {
    public RawImage videoDisplay;  // UI RawImage for displaying the video
    public VideoPlayer videoPlayer; // Video Player component
    public string videoFileName = "video.mp4"; // MP4 file name

    private string videoPath;

    void Start() {
        // Construct the full path to the SharedResource folder
        videoPath = Path.Combine(Application.streamingAssetsPath, "SharedResource", videoFileName);

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

    // Play the video
    public void PlayVideo() {
        if (videoPlayer.isPrepared) {
            videoPlayer.Play();
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
}
