//using UnityEngine;

//public class Trap : MonoBehaviour
//{
//    public int damagePerSecond = 5; // Số máu mất mỗi giây
//    private bool isPlayerInTrap = false; // Kiểm tra người chơi có trong bẫy không
//    private Player playerHealth;

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        // Kiểm tra xem đối tượng chạm vào có phải là người chơi
//        if (collision.CompareTag("Player"))
//        {
//            playerHealth = collision.GetComponent<Player>();
//            if (playerHealth != null)
//            {
//                isPlayerInTrap = true; // Bắt đầu trừ máu
//                StartCoroutine(DamagePlayer());
//            }
//        }
//    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        // Khi người chơi rời khỏi bẫy
//        if (collision.CompareTag("Player"))
//        {
//            isPlayerInTrap = false; // Dừng trừ máu
//        }
//    }

//    private System.Collections.IEnumerator DamagePlayer()
//    {
        
//        while (isPlayerInTrap && playerHealth != null)
//        {
//            playerHealth.TakeDamage(damagePerSecond);
//            yield return new WaitForSeconds(1f); // Mỗi giây trừ máu một lần
//        }
//    }
//}
