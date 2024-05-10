using UnityEngine;

public class DoubleScore : MonoBehaviour
{
    // Thời gian kéo dài tính năng Double Score
    public float duration = 10f;

    // Âm thanh khi kích hoạt Double Score (tùy chọn)
    public AudioClip sound;

    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra nếu người chơi va chạm với đối tượng Double Score
        if (!(other.CompareTag("Fruit") || other.CompareTag("Bomb")))
        {
            // Kích hoạt tính năng Double Score trong GameManager
            GameManager.Instance.ActivateDoubleScore(duration);

            // Phát âm thanh nếu có
            if (sound != null)
            {
                AudioSource.PlayClipAtPoint(sound, transform.position);
            }

            // Tắt đối tượng Double Score sau khi được kích hoạt
            Destroy(gameObject);

        }
    }
}
