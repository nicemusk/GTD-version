using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Text HeartCountingText;  // �ν�����â ��Ʈtext ����ĭ
    // Update is called once per frame
    void Update()
    {
        HeartCountingText.text = PlayerStats.Heart.ToString();  //PlayerStats�� ��Ʈ����ǥ��
        
    }
}
