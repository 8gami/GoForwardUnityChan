using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

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
    //【3月12日メンタリング用】collision:Collision2D
    void OnCollisionEnter2D(Collision2D collision)
    {
        //【3月12日メンタリング用】「引数」が「Collision」系なので、「OnTriggerEnter2D」と違い「collision.gameObject」から「tag」の情報を入手
        if (collision.gameObject.tag == "Cube")
        {
            //Debug.Log("キューブ");
            audioSource.PlayOneShot(SE1);
        }
        else if(collision.gameObject.tag == "ground")
        {
            //Debug.Log("地面");
            audioSource.PlayOneShot(SE1);
        }
        //Unityちゃんとの衝突で音が鳴らないかの確認用
        //else if (collision.gameObject.tag == "Player")
        //{
            //Debug.Log("人");
        //}
    }
}