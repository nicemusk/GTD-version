using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Set : MonoBehaviour
{
    public GameObject menuset;// Inspector 창에 메뉴세팅(menuset) 선언
    public GameObject TwBuy; //  Inspector 창에 타워Buy(TwBuy)  선언
    

   

    public void Update()
    {
        if (Input.GetButtonDown("Cancel")) // ESC 버튼으로 설정창 띄우기
        {
            if (menuset.activeSelf)
            {
                menuset.SetActive(false); // 메뉴세팅창이 비활성화되면
                Time.timeScale = 1.0f;    // 게임 시간이 정상으로 동작한다.
            }
            else
            {
                menuset.SetActive(true); // 메뉴세팅창이 활성화되면
                Time.timeScale = 0f;     // 게임 시간을 멈춘다.(pause기능)
            }

        }
       
        if (Input.GetKeyDown(KeyCode.B)) //"B" 버튼으로 고양이 빌딩바 띄우기
        {
            if (TwBuy.activeSelf)
                TwBuy.SetActive(false);
            else
                TwBuy.SetActive(true);

        }
        

        
    }
    public void TimeStop() //BTN 버튼 누를 시 퍼즈 기능
    {
        Time.timeScale = 0f;
    }
    public void TimeContinue() //계속하기 버튼 누를 시 게임 계속하기
    {
        Time.timeScale = 1f;
    }
}
