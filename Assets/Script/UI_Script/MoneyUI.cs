using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text FishCountingText;  // ?????????? ????text ??????
    void Update()
    {
        FishCountingText.text = PlayerStats.Money.ToString();  //?????????? PlayerStats?????????? ????????????
    }
}
