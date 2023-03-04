using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

     public static float setTime1; //시간 다른스크립트로 넘길수 있게 setTime1 static선언

    [SerializeField] float setTime = 300f; //초기시간 300초(5분)
     [SerializeField] Text countdownText; //인스펙터창에서 ui 카운트text 넣는칸
    

    // Start is called before the first frame update
    void Start()
    {
        countdownText.text = setTime.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (setTime > 0)
            setTime -= Time.deltaTime;

        else if (setTime <= 0)
            Time.timeScale = 0.0f; // 게임 시간을 멈춘다.(pause기능)


        countdownText.text = string.Format("{00:00.00}", setTime); // 30.00 초로 카운트다운

        //countdownText.text = string.Format("{00}", setTime); //소수점 다나옴
        // {0:00.00} 로 바꾸면 30:00 초로 카운트다운
        //countdownText.text = Mathf.Round(setTime).ToString(); // 정수로(소수점잘림)

        setTime1 = setTime; //setTime시간 setTime1 로 대입
    }


}