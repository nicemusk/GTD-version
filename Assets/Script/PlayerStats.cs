using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    
    
    public static int Money;
    public int startMoney = 400; //�ʱ���ȭ ����

    public static int Heart;
    public int startHeart = 10; //�ʱ���Ʈ ����

    public static int Rounds;
    public int startRound = 1;

    private void Start()
    {
        
        Money = startMoney; //��ȭ
        Heart = startHeart; //��Ʈ
        
    
    }
}