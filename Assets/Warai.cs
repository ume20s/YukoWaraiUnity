using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Warai : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // 変数もろもろ
    private bool isLaughing = false;                        // 笑い中
    private int laughTimes = 4;                             // 笑い回数
    private int laughKoe = 0;                               // 笑い声の番号(0~4)

    // 音声関連
    AudioSource audioSource;
    public AudioClip vYukodesu;                             // ゆうこです！
    public AudioClip[] vWarai = new AudioClip[4];           // 笑い声４種
    public AudioClip vWaraiEnd;                             // へぇ

    // ゲームオブジェクト
    GameObject warai;                                       // 笑いグラフィック
    Animator anime;                                         // アニメーション

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ゲームオブジェクトの取得
        warai = GameObject.Find("warai");

        // アニメーションコンポーネントの取得
        anime = GetComponent<Animator>();

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
        // 笑い中ならもろもろ操作
        if (isLaughing)
        {
            // 笑ってて再生中ならなにもせずに続行
            if (audioSource.isPlaying)
            {
                return;
            }
            // 笑ってて再生終わりなら
            else
            {
                audioSource.Stop();     // 無駄ルーチンだけど念のため再生終了しておく
                // まだ２回以上笑うなら別の声で笑い始める
                if (laughTimes > 1)
                {
                    laughKoe = (laughKoe + Random.Range(1, 4)) % 4;
                    audioSource.PlayOneShot(vWarai[laughKoe]);
                    laughTimes -= 1;
                }
                else
                {
                    // 最後の１回なら「へぇ」を言ってから終了
                    if (laughTimes == 1)
                    {
                        StartCoroutine("sayHee");
                    }
                }
            }
        }
    }

    // 「へぇ」と言ってから終了プロセス
    IEnumerator sayHee()
    {
        laughTimes -= 1;
        anime.SetTrigger("HeeTrigger");
        audioSource.PlayOneShot(vWaraiEnd);
        yield return new WaitForSeconds(1.3f);
        anime.SetTrigger("StayTrigger");
        isLaughing = false;
    }

    // タップされたら笑いだす
    public void tapToLaugh()
    {
        // もし笑い中じゃなかったら
        if(!isLaughing)
        {
            // 笑いだす
            anime.SetTrigger("WaraiTrigger");
            isLaughing = true;
            laughTimes = Random.Range(4, 5);
        }
    }
}
