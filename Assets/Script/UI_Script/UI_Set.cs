using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Set : MonoBehaviour
{
    public GameObject menuset;// Inspector â�� �޴�����(menuset) ����
    public GameObject TwBuy; //  Inspector â�� Ÿ��Buy(TwBuy)  ����
    

   

    public void Update()
    {
        if (Input.GetButtonDown("Cancel")) // ESC ��ư���� ����â ����
        {
            if (menuset.activeSelf)
            {
                menuset.SetActive(false); // �޴�����â�� ��Ȱ��ȭ�Ǹ�
                Time.timeScale = 1.0f;    // ���� �ð��� �������� �����Ѵ�.
            }
            else
            {
                menuset.SetActive(true); // �޴�����â�� Ȱ��ȭ�Ǹ�
                Time.timeScale = 0f;     // ���� �ð��� �����.(pause���)
            }

        }
       
        if (Input.GetKeyDown(KeyCode.B)) //"B" ��ư���� ����� ������ ����
        {
            if (TwBuy.activeSelf)
                TwBuy.SetActive(false);
            else
                TwBuy.SetActive(true);

        }
        

        
    }
    public void TimeStop() //BTN ��ư ���� �� ���� ���
    {
        Time.timeScale = 0f;
    }
    public void TimeContinue() //����ϱ� ��ư ���� �� ���� ����ϱ�
    {
        Time.timeScale = 1f;
    }
}
