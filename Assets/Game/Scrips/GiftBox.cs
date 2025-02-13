using UnityEngine;
using UnityEngine.UI;

public class GiftBox : MonoBehaviour
{
    public GameObject messagePanel; // Bảng chứa các lời chúc Giáng Sinh
    public Text messageText; // Text để hiển thị lời chúc
    public Image backgroundImage; // Nền dưới dòng chữ
    public Button closeButton; // Nút đóng bảng thông báo

    private string[] christmasMessages = {
        "Santa thân mến,Hôm nay là một ngày đặc biệt, để cảm ơn cho sự cố gắng và nỗ lực không ngừng nghỉ của bạn trong suất một năm qua chúng tôi đã chuẩn bị một món quà vô cùng đặc biệt dành riêng cho bạn, món quà được đặt ở trên đỉnh núi tuyết, hãy tới đó nhé."
    };

    private void Start()
    {
        closeButton.onClick.AddListener(HideMessage); // Gán sự kiện cho nút đóng
        messagePanel.SetActive(false); // Ẩn bảng thông báo lúc đầu
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShowRandomMessage();
        }
    }

    void ShowRandomMessage()
    {
        int randomIndex = Random.Range(0, christmasMessages.Length);
        messageText.text = christmasMessages[randomIndex];
        messagePanel.SetActive(true);
    }

    void HideMessage()
    {
        messagePanel.SetActive(false); // Ẩn bảng thông báo
    }
}
