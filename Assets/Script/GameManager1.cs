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

        if (PlayerStats.Heart <= 0) //하트가 0이거나 0보다 작으면 EndGame()호출
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

        Time.timeScale = 0f;     // 게임 시간을 멈춘다.(pause기능)
        DefeatPOP_UP.SetActive(true); // 패배창 활성화(체크해제 해놓은거)
           
    }
   
}
