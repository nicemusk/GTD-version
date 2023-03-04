using System.Collections;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public GameObject DefeatPOP_UP;
    private bool gameEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return;

        if (PlayerStats.Heart <= 0) //��Ʈ�� 0�̰ų� 0���� ������ EndGame()ȣ��
        {
           EndGame();
        }

        /*else if(Timer.setTime1 <= 0)
        {
            EndGame();
        }*/
    }

    void EndGame()
    {
        gameEnded = true;
        // Debug.Log("Game Over!");

        Time.timeScale = 0f;     // ���� �ð��� �����.(pause���)
        DefeatPOP_UP.SetActive(true); // �й�â Ȱ��ȭ(üũ���� �س�����)
           
    }
   
}
