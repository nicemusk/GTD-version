using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Timer_Test : MonoBehaviour
{
    private float timeDuration = 0f; // �������� �� �ʱ� ���ӽð� ����
                                          //�ʴ��� �̹Ƿ� *60f �� �ϴ°�

    private float timer_Test;

    [SerializeField]
    private Text firstMinute;  // �ν�����â ù�� ° "��" ǥ�� 
    [SerializeField]
    private Text secondMinute; // �ν�����â �ι� ° "��" ǥ��
    [SerializeField]
    private Text separator;    // �ν�����â ���� ° ":" ǥ��
    [SerializeField]
    private Text firstSecond;  // �ν�����â ù�� ° "��" ǥ��
    [SerializeField]
    private Text secondSecond; // �ν�����â �ι� ° "��" ǥ��





    // Start is called before the first frame update
    void Start()
    {
        ResetTimer(); //�����ϸ� timeDuration���� ������ ������ ����
    }

    // Update is called once per frame
    void Update()
    {
        if (timer_Test >= 0)
        {    timer_Test += Time.deltaTime;
        UpdateTimerDisplay(timer_Test); //���÷��̸� ������Ʈ ���
        }
        else
        {
        Flash();
        }               
    }

    private void ResetTimer()
    {
        timer_Test = timeDuration; //Ÿ�̸� �缳�� ���
                                   //Ÿ�̸Ӹ� ���� �ð��� �����ϰ� �����ϰ� ���� ��� ����
    }

    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60); //����Ÿ�̸� ���� ���� ���� [��]
        float seconds = Mathf.FloorToInt(time % 60); //����Ÿ�̸� ���� ���� ���� [��]

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds); //���ڿ� �� ����
        firstMinute.text = currentTime[0].ToString();  //���� �ð��� ���� ���ڿ� ����
        secondMinute.text = currentTime[1].ToString(); //���� �ð��� ���� ���ڿ� ����
        firstSecond.text = currentTime[2].ToString();  //���� �ð��� ���� ���ڿ� ����
        secondSecond.text = currentTime[3].ToString(); //���� �ð��� ���� ���ڿ� ����
    }
        
    private void Flash()
    {

    }
}
