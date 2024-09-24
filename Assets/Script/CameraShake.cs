using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration = 2f; // Durasi getaran
    public float magnitude = 0.1f; // Intensitas getaran
    private Vector3 originalPos; // Variabel untuk menyimpan posisi awal kamera

    // Fungsi Start dijalankan saat object aktif
    void Start()
    {
        // Simpan posisi awal kamera saat game dimulai
        originalPos = transform.localPosition;
    }

    // Fungsi untuk memulai Coroutine getaran
    public IEnumerator Shake()
    {
        float elapsed = 0.0f;

        // Loop getaran selama durasi yang ditentukan
        while (elapsed < duration)
        {
            // Acak posisi kamera dalam sumbu x dan y
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            // Pindahkan kamera ke posisi acak, tetap menjaga posisi z asli
            transform.localPosition = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime; // Hitung waktu yang telah berlalu

            yield return null; // Tunggu frame berikutnya
        }

        // Kembalikan kamera ke posisi asli setelah getaran berakhir
        transform.localPosition = originalPos;
    }
}
