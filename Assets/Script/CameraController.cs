using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    //�Q�[���I�u�W�F�N�g��ǋL
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���I�u�W�F�N�g��ݒ�
        this.player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        //�Ǐ]����悤�ɐݒ�
        Vector3 playerPos = this.player.transform.position;

        //�J�����̍��W��ύX������
        transform.position=new Vector3(transform.position.x,playerPos.y,transform.position.z);
    }
}
