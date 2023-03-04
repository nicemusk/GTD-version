using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 1.2f; //�ӵ�

    public int health = 100; //�ʱ� ü��
    private int checkhealth;

    public int value = 10; //�� �ı��Ǹ� �ö󰡴� ��ȭ�� �ʱ�ġ 10 
    public bool isUnBeatTime;
    public float unBeatTime;
    private Transform target;
    private int wavepointIndex = 0; //��������Ʈ �ε���(��������Ʈ �������� 0)


    void Start()  // Ÿ���� ������������ ����Ʈ��
    {
        target = Waypoints.points[0];
        checkhealth = health;
    }

    // ������ �޴�
    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= -1) //health �� 0�� �Ǹ� Die()ȣ��
        {
            isUnBeatTime = true;
            gameObject.tag = "asdf";
            Destroy(gameObject);
            isUnBeatTime = false;
            //new WaitForSeconds(2);
            TakeDamage2();
            

        }
    }
    public void TakeDamage2()
    {
        if (gameObject.tag == "asdf")
        {
            
         health = 0;
         if (health == 0)
           {
             Die();
            }

            
        }

    }

    void Die()
    {
        
        PlayerStats.Money += value; //����� �Ӵ� value����ŭ ���ϱ�
       
        Destroy(gameObject); //������Ʈ �ı�
        

    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // ���� ��������Ʈ�� �̵�
        if (Vector3.Distance(transform.position, target.position) <= 0.4f) //��������Ʈ�� enemy �� ��� �Ÿ�����
        {
            GetNextWaypoint();
            transform.Rotate(0, -90, 0); //enemy�� y������ -90��ȸ��
        }
    }

    private void GetNextWaypoint()
    {
        // �������� ��������Ʈ�� ������ ������Ʈ �ı�
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            
            //Destroy(gameObject);
            EndPath(); //EndPath ()ȣ��
            return;
        }

        wavepointIndex++; //��������Ʈ ����������ȣ ���ϱ�(��������)
        target = Waypoints.points[wavepointIndex]; // Waypoints�� wavepointIndex(��������Ʈ ��������)�� target�� ����

    }

    void EndPath()
    {
        
        PlayerStats.Heart--; //��Ʈ -1�� ����
        Destroy(gameObject); //������Ʈ �ı�
        //WaveSpawner.EnemiesAlive--;
    }
}
