using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamestart : MonoBehaviour
{
    // 게임재시작
    public void GameStart()
    {
        SceneManager.LoadScene("Game Play Screen"); //게임 플레이 씬 로드
        WaveSpawner.ene = 0; //게임스폰 초기화
        Time.timeScale = 1.0f;
    }
}
