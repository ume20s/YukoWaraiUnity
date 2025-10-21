using UnityEngine;

public class WaraiDirector : MonoBehaviour
{
    // 音声関連
    AudioSource audioSource;
    public AudioClip vYukodesu;                             // ゆうこです！
    public AudioClip[] vWarai = new AudioClip[5];           // 笑い声３種

    // ゲームオブジェクト
    GameObject[] waraiImage = new GameObject[3];            // おてつきグラフィック


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ゲームオブジェクトの取得

        // 音声コンポーネントの取得
        audioSource = GetComponent<AudioSource>();

        // 最初に元気よく「ゆうこです！」        
        audioSource.PlayOneShot(vYukodesu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
