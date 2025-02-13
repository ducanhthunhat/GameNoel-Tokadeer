using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    private Animator anim;
    public GameObject bulletPrefab; // Đạn của enemy
    public Transform firePoint; // Điểm mà đạn sẽ bắn ra
    public float shootInterval = 2f; // Khoảng thời gian giữa các lần bắn

    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("Shoot", 0f, shootInterval); // Lệnh gọi hàm Shoot mỗi shootInterval giây
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Tạo ra đạn tại vị trí firePoint
    }
}
