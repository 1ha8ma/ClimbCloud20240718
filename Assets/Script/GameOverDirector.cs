using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDirector : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //マウスがおされたら
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
