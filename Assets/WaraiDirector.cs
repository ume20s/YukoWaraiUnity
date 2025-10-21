using UnityEngine;

public class WaraiDirector : MonoBehaviour
{
    // 音声関連
    AudioSource audioSource;
    public AudioClip vYukodesu;
    public AudioClip[] vWarai = new AudioClip[5];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 音声コンポーネントの取得
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(vYukodesu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
