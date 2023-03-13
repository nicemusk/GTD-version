using System.Collections;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public GameObject DefeatPOP_UP;
    private bool gameEnded = false;


    private void Start()
    {
        scSoundManager.instance.PlayBGM("BGM_play");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return;

        if (PlayerStats.Heart <= 0) //?????? 0?????? 0???? ?????? EndGame()????
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

        Time.timeScale = 0f;     // ???? ?????? ??????.(pause????)
        DefeatPOP_UP.SetActive(true); // ?????? ??????(???????? ????????)
           
    }
   
}
