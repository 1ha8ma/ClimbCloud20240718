using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigidbody2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxwalkForce = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーをとる
        this.player = GameObject.Find("cat");
        Application.targetFrameRate = 60;
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー位置を取得
        Vector3 playerPos = this.player.transform.position;

        //スペースキーでジャンプする
        if (Input.GetKey(KeyCode.Space) && this.rigidbody2D.velocity.y == 0)
        {
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);
            animator.SetTrigger("jump_trigger");
        }

        //左右のキー入力で横移動
        int key = 0;
        if (Input.GetKeyDown(KeyCode.RightArrow)) key = 1;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) key = -1;

        //プレイヤーの速度
        float speedx = Mathf.Abs(this.rigidbody2D.velocity.x);

        //スピード制限
        if (speedx < this.maxwalkForce)
        {
            this.rigidbody2D.AddForce(transform.right * key * this.walkForce);
        }

        //動く方向に応じて反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //下に落ちたらプレイヤーを一番下の雲まで戻す
        if (playerPos.y <= -6)
        {
            playerPos.y = -4;
            playerPos.x = 0;
        }

        //下に落ちたらシーン変更
        //if (transform.position.y < -10)
        //{
        //    SceneManager.LoadScene("GameScene");
        //}
        //else if (transform.position.y > 17)
        //{
        //    this.transform.position.y = new Vector3(transform.position.x);
        //}

        //両端の画面外に行かないようにする
        if (playerPos.x < -9)
        {
            playerPos.x = -9;
        }
        if (playerPos.x > 9)
        {
            playerPos.x = 9;
        }
        if (playerPos.y > 25)
        {
            playerPos.y =25;
        }


        //プレイヤーの速度に応じてアニメーション速度を変える
        this.animator.speed = speedx / 2.0f;

        //座標を設定
        player.transform.position = playerPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Goal");
        SceneManager.LoadScene("ClearScene");
    }
}
