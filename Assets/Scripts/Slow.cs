using UnityEngine;

public class Slow : MonoBehaviour
{
    // Tỉ lệ giảm tốc độ
    public float slowFactor = 0.5f;

    // Âm thanh khi nhặt power-up
    public AudioClip pickUpSound;
    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra nếu đối tượng va chạm có tag là "Fruit"
        if (other.CompareTag("Fruit"))
        {
            // Lấy tất cả các đối tượng Fruit có hiệu lực trong cảnh
            GameObject[] fruits = GameObject.FindGameObjectsWithTag("Fruit");

            // Lặp qua từng đối tượng Fruit và làm chậm tốc độ bay của chúng
            foreach (GameObject fruit in fruits)
            {
                // Kiểm tra xem đối tượng Fruit có đang hoạt động hay không
                if (fruit.activeSelf)
                {
                    // Lấy component Rigidbody của đối tượng Fruit
                    Rigidbody rb = fruit.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        // Giảm tốc độ bay của đối tượng Fruit
                        rb.velocity *= slowFactor;
                    }
                }
            }

            if (pickUpSound != null)
            {
                AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            }
            // Sau khi làm chậm tốc độ của các đối tượng Fruit, hủy đối tượng Slow
            Destroy(gameObject);
        }
    }
}
