using UnityEngine;

public class WaraiDirector : MonoBehaviour
{
    // 変数もろもろ
    static public bool isLaughing = false;                  // 笑い中

    // 音声関連
    AudioSource audioSource;
    public AudioClip vYukodesu;                             // ゆうこです！
    public AudioClip[] vWarai = new AudioClip[5];           // 笑い声３種

    // ゲームオブジェクト
    GameObject waraiStay;            //


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ゲームオブジェクトの取得
        waraiStay = GameObject.Find("stay");

        // 音声コンポーネントの取得
        audioSource = GetComponent<AudioSource>();

        // 最初に元気よく「ゆうこです！」        
        audioSource.PlayOneShot(vYukodesu);

        // 笑い中オフ
        isLaughing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLaughing)
        {
            audioSource.PlayOneShot(vWarai[0]);
            isLaughing = false;
        }
    }
}
