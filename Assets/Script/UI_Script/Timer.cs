using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

     public static float setTime1; //�ð� �ٸ���ũ��Ʈ�� �ѱ�� �ְ� setTime1 static����

    [SerializeField] float setTime = 300f; //�ʱ�ð� 300��(5��)
     [SerializeField] Text countdownText; //�ν�����â���� ui ī��Ʈtext �ִ�ĭ
    

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
            Time.timeScale = 0.0f; // ���� �ð��� �����.(pause���)


        countdownText.text = string.Format("{00:00.00}", setTime); // 30.00 �ʷ� ī��Ʈ�ٿ�

        //countdownText.text = string.Format("{00}", setTime); //�Ҽ��� �ٳ���
        // {0:00.00} �� �ٲٸ� 30:00 �ʷ� ī��Ʈ�ٿ�
        //countdownText.text = Mathf.Round(setTime).ToString(); // ������(�Ҽ����߸�)

        setTime1 = setTime; //setTime�ð� setTime1 �� ����
    }


}