using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    
    
    public static int Money;
    public int startMoney = 400; //초기재화 설정

    public static int Heart;
    public int startHeart = 10; //초기하트 설정

    public static int Rounds;
    public int startRound = 1;

    private void Start()
    {
        
        Money = startMoney; //재화
        Heart = startHeart; //하트
        
    
    }
}