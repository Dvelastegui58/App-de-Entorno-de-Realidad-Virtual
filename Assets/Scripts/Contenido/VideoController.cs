using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void PlayVideo()
    {
        videoPlayer.Play();
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
    }

    public void Adelantar()
    {
        if (videoPlayer.canSetTime)
            videoPlayer.time += 5f;
    }

    public void Retroceder()
    {
        if (videoPlayer.canSetTime)
            videoPlayer.time -= 5f;
    }
}
