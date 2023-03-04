using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public float speed = 1f; //�ӵ�

    public int health = 100; //�ʱ� ü��

    public int value = 10; //�� �ı��Ǹ� �ö󰡴� ��ȭ�� �ʱ�ġ 10 

    private Transform target;
    private int wavepointIndex = 0; //��������Ʈ �ε���(��������Ʈ �������� 0)


    void Start()  // Ÿ���� ������������ ����Ʈ��
    {
        target = Waypoints.points[0];
    }

    // ������ �޴�
    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0) //health �� 0�� �Ǹ� Die()ȣ��
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value; //����� �Ӵ� value����ŭ ���ϱ�
        WaveSpawner.EnemiesAlive--;
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
        WaveSpawner.EnemiesAlive--;
        PlayerStats.Heart-=5; //��Ʈ -1�� ����
        Destroy(gameObject); //������Ʈ �ı�
  
    }
}
