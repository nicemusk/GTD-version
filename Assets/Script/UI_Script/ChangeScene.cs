using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneBtn()
    {
        switch (this.gameObject.name)
        {
            case "BTNGameStart": //GameStart ��ư�� ������ �� ��ũ��Ʈ
                SceneManager.LoadScene("Game Play Screen"); // ���� �÷��� �� �ε�
                WaveSpawner.ene = 0; //���ӽ��� �ʱ�ȭ
               

                Time.timeScale = 1.0f;
                break;

            case "BTNGameExplanation": //GameExplanation ��ư�� ������ �� ��ũ��Ʈ
                SceneManager.LoadScene("Game Explanation");//���� ���� �� �ε�
                break;

            case "BTNGameEnd": //GameEnd ��ư ������ �� ��ũ��Ʈ
                Application.Quit(); // ���ø����̼� ����
                break;


                
                
        }
    }
}
