using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    //ゲームオブジェクトを追記
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //ゲームオブジェクトを設定
        this.player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        //追従するように設定
        Vector3 playerPos = this.player.transform.position;

        //カメラの座標を変更させる
        transform.position=new Vector3(transform.position.x,playerPos.y,transform.position.z);
    }
}
