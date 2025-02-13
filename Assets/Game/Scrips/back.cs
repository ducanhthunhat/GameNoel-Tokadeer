using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Tham chiếu đến VideoPlayer
    public string menuSceneName = "Menu"; // Tên Scene Menu (đổi thành tên Scene của bạn)

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd; // Đăng ký sự kiện khi video kết thúc
            videoPlayer.Play(); // Bắt đầu phát video
        }
        else
        {
            Debug.LogError("VideoPlayer not assigned!");
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("Menu");
    }
}
