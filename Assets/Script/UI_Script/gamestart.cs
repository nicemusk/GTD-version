using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamestart : MonoBehaviour
{
    // ���������
    public void GameStart()
    {
        SceneManager.LoadScene("Game Play Screen"); //���� �÷��� �� �ε�
        WaveSpawner.ene = 0; //���ӽ��� �ʱ�ȭ
        Time.timeScale = 1.0f;
    }
}
