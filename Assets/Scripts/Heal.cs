using UnityEngine;

public class Heal : MonoBehaviour
{
    public int heartsToAdd = 1; // Số lượng heart sẽ được thêm khi chạm vào power-up item
    public AudioClip sound;
    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem người chơi đã chạm vào collider của power-up item chưa
        if (other.CompareTag("Player"))
        {
            // Lấy tham chiếu tới GameManager thông qua singleton
            GameManager gameManager = GameManager.Instance;

            // Kiểm tra xem GameManager có tồn tại không
            if (gameManager != null)
            {
                // Tăng số lượng hearts trong GameManager
                gameManager.IncreaseHearts(heartsToAdd);

                if (sound != null)
                {
                    AudioSource.PlayClipAtPoint(sound, transform.position);
                }

                // Xóa power-up item khỏi scene
                Destroy(gameObject);
            }
        }
    }
}