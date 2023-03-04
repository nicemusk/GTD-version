using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Timer_Test : MonoBehaviour
{
    private float timeDuration = 0f; // 변수선언 및 초기 지속시간 설정
                                          //초단위 이므로 *60f 를 하는것

    private float timer_Test;

    [SerializeField]
    private Text firstMinute;  // 인스펙터창 첫번 째 "분" 표시 
    [SerializeField]
    private Text secondMinute; // 인스펙터창 두번 째 "분" 표시
    [SerializeField]
    private Text separator;    // 인스펙터창 세번 째 ":" 표시
    [SerializeField]
    private Text firstSecond;  // 인스펙터창 첫번 째 "초" 표시
    [SerializeField]
    private Text secondSecond; // 인스펙터창 두번 째 "초" 표시





    // Start is called before the first frame update
    void Start()
    {
        ResetTimer(); //시작하면 timeDuration에서 설정한 값으로 시작
    }

    // Update is called once per frame
    void Update()
    {
        if (timer_Test >= 0)
        {    timer_Test += Time.deltaTime;
        UpdateTimerDisplay(timer_Test); //디스플레이를 업데이트 기능
        }
        else
        {
        Flash();
        }               
    }

    private void ResetTimer()
    {
        timer_Test = timeDuration; //타이머 재설정 기능
                                   //타이머를 지속 시간과 동일하게 설정하고 싶은 경우 설정
    }

    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60); //가변타이머 로컬 변수 선언 [분]
        float seconds = Mathf.FloorToInt(time % 60); //가변타이머 로컬 변수 선언 [초]

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds); //문자열 점 형식
        firstMinute.text = currentTime[0].ToString();  //현재 시간에 대한 문자열 생성
        secondMinute.text = currentTime[1].ToString(); //현재 시간에 대한 문자열 생성
        firstSecond.text = currentTime[2].ToString();  //현재 시간에 대한 문자열 생성
        secondSecond.text = currentTime[3].ToString(); //현재 시간에 대한 문자열 생성
    }
        
    private void Flash()
    {

    }
}
