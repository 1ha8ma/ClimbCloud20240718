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
        //�v���C���[���Ƃ�
        this.player = GameObject.Find("cat");
        Application.targetFrameRate = 60;
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�ʒu���擾
        Vector3 playerPos = this.player.transform.position;

        //�X�y�[�X�L�[�ŃW�����v����
        if (Input.GetKey(KeyCode.Space) && this.rigidbody2D.velocity.y == 0)
        {
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);
            animator.SetTrigger("jump_trigger");
        }

        //���E�̃L�[���͂ŉ��ړ�
        int key = 0;
        if (Input.GetKeyDown(KeyCode.RightArrow)) key = 1;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) key = -1;

        //�v���C���[�̑��x
        float speedx = Mathf.Abs(this.rigidbody2D.velocity.x);

        //�X�s�[�h����
        if (speedx < this.maxwalkForce)
        {
            this.rigidbody2D.AddForce(transform.right * key * this.walkForce);
        }

        //���������ɉ����Ĕ��]
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //���ɗ�������v���C���[����ԉ��̉_�܂Ŗ߂�
        if (playerPos.y <= -6)
        {
            playerPos.y = -4;
            playerPos.x = 0;
        }

        //���ɗ�������V�[���ύX
        //if (transform.position.y < -10)
        //{
        //    SceneManager.LoadScene("GameScene");
        //}
        //else if (transform.position.y > 17)
        //{
        //    this.transform.position.y = new Vector3(transform.position.x);
        //}

        //���[�̉�ʊO�ɍs���Ȃ��悤�ɂ���
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


        //�v���C���[�̑��x�ɉ����ăA�j���[�V�������x��ς���
        this.animator.speed = speedx / 2.0f;

        //���W��ݒ�
        player.transform.position = playerPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Goal");
        SceneManager.LoadScene("ClearScene");
    }
}
