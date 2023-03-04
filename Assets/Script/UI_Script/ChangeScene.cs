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
            case "BTNGameStart": //GameStart 버튼을 눌렀을 때 스크립트
                SceneManager.LoadScene("Game Play Screen"); // 게임 플레이 씬 로드
                WaveSpawner.ene = 0; //게임스폰 초기화
               

                Time.timeScale = 1.0f;
                break;

            case "BTNGameExplanation": //GameExplanation 버튼을 눌렀을 때 스크립트
                SceneManager.LoadScene("Game Explanation");//게임 설명 씬 로드
                break;

            case "BTNGameEnd": //GameEnd 버튼 눌렀을 때 스크립트
                Application.Quit(); // 애플리케이션 종료
                break;


                
                
        }
    }
}
