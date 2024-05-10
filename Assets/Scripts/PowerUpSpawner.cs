using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs; // Prefab của power-up

    public float spawnInterval = 10f; // Thời gian giữa các lần spawn
    public float spawnRadius = 5f; // Bán kính để random vị trí spawn
    public float spawnHeight = 3f; // Độ cao để spawn power-up phía trên
    public float rotationAngleX = 90f; // Góc xoay của power-up theo trục x khi spawn
    public float rotationAngleY = 120f; // Góc xoay của power-up theo trục y khi spawn

    public float despawnDelay = 5f; // Thời gian trước khi xóa prefab

    private float timer; // Đếm thời gian

    private void Start()
    {
        // Bắt đầu với một khoảng thời gian ngẫu nhiên để spawn lần đầu tiên
        timer = Random.Range(0f, spawnInterval);
    }

    private void Update()
    {
        // Đếm thời gian
        timer += Time.deltaTime;

        // Kiểm tra nếu đến lúc spawn mới
        if (timer >= spawnInterval)
        {
            // Reset timer
            timer = 0f;

            // Random chọn prefab của power-up từ mảng
            GameObject selectedPowerUpPrefab = powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)];

            // Tính toán vị trí spawn xung quanh vị trí của PowerUpSpawner
            Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
            randomOffset.y = Mathf.Abs(randomOffset.y); // Đảm bảo offset y là dương

            // Tính toán vị trí spawn, không có phần tử y
            Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, spawnHeight, randomOffset.z);

            // Spawn power-up
            GameObject spawnedPowerUp = Instantiate(selectedPowerUpPrefab, spawnPosition, Quaternion.identity);

            // Xoay power-up
            spawnedPowerUp.transform.Rotate(rotationAngleX, rotationAngleY, 0f);

            // Xóa prefab sau khoảng thời gian despawnDelay
            Destroy(spawnedPowerUp, despawnDelay);
        }
    }
}
