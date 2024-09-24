using UnityEngine;

public class EarthquakeTrigger : MonoBehaviour
{
    public CameraShake cameraShake; // Referensi ke script CameraShake
    public bool earthquakeStarted = false; // Cek apakah gempa sudah dimulai

    // Fungsi untuk mendeteksi masuknya objek ke dalam trigger
    private void OnTriggerEnter(Collider other)
    {
        // Pastikan objek yang masuk trigger adalah pemain (atau objek tertentu)
        if (other.CompareTag("Player") && !earthquakeStarted)
        {
            earthquakeStarted = true; // Menandai bahwa gempa telah dimulai
            StartCoroutine(cameraShake.Shake()); // Memulai getaran kamera
            Debug.Log("Gempa dimulai!");
        }
    }
}
