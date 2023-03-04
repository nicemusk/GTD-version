using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Text HeartCountingText;  // 인스펙터창 하트text 삽입칸
    // Update is called once per frame
    void Update()
    {
        HeartCountingText.text = PlayerStats.Heart.ToString();  //PlayerStats의 하트감소표시
        
    }
}
