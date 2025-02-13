using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform pointA; // Điểm tuần tra A
    public Transform pointB; // Điểm tuần tra B
    public float speed = 2.0f; // Tốc độ di chuyển của enemy
    private Transform targetPoint; // Điểm đích hiện tại

    void Start()
    {
        targetPoint = pointA; // Bắt đầu từ điểm A
    }

    void Update()
    {
        // Di chuyển đến điểm đích hiện tại
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // Kiểm tra nếu đã đến điểm đích hiện tại
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            // Chuyển đổi điểm đích
            if (targetPoint == pointA)
            {
                targetPoint = pointB;
                transform.Rotate(0, 180, 0);
            }
            else
            {
                targetPoint = pointA;
                transform.Rotate(0, 180, 0);

            }
        }
        

    }

}
