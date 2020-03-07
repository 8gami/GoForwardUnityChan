using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    //【課題用】地面の位置
    //private float groundLevel = -3.0f;

    //【課題用】音声ファイル用の変数を設定
    public AudioClip SE1;
    //【課題用】AudioSourceのコンポーネント取得用変数を設定
    private AudioSource audioSource;


    // Use this for initialization
    void Start()
    {
        // AudioSourceコンポーネントを変数audioSourceに格納する
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //【課題用】「BoxCollider2D」をアタッチしているオブジェクトで使用する関数は、「OnCollisionEnter」ではなく「OnCollisionEnter2D」
    void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(SE1);
    }

}