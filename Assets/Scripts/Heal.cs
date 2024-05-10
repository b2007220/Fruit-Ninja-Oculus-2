using UnityEngine;

public class Heal : MonoBehaviour
{
    public int heartsToAdd = 1; // Số lượng heart sẽ được thêm khi chạm vào power-up item
    public AudioClip pickUpSound; // Reference to the AudioSource component

    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem người chơi đã chạm vào collider của power-up item chưa
        if (!(other.CompareTag("Fruit") || other.CompareTag("Bomb")))
        {
            // Lấy tham chiếu tới GameManager thông qua singleton
            GameManager gameManager = GameManager.Instance;

            // Kiểm tra xem GameManager có tồn tại không
            if (gameManager != null)
            {
                // Tăng số lượng hearts trong GameManager
                gameManager.IncreaseHearts(heartsToAdd);

                // Xóa power-up item khỏi scene
                Destroy(gameObject);

                // Phát âm thanh từ AudioSource
                if (pickUpSound != null)
                {
                    AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
                }
            }
        }
    }
}