using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2 : MonoBehaviour
{
    public float speed = 1f; //�ӵ�

    public int health = 500; //�ʱ� ü��

    public int value = 1000; //�� �ı��Ǹ� �ö󰡴� ��ȭ�� �ʱ�ġ 10 
    
    private Transform target;
    private int wavepointIndex = 0; //��������Ʈ �ε���(��������Ʈ �������� 0)
    public GameObject VictoryPOP_UP;

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
            WaveSpawner.EnemiesAlive--;
            Die();
        }
    }

    void Die()
    {
        
        Debug.Log("�¸�");
        VicGame();

        Destroy(gameObject); //������Ʈ �ı�
       

        Time.timeScale = 0f;     // ���� �ð��� �����.(pause���)
        //DefeatPOP_UP.SetActive(true); // �й�â Ȱ��ȭ(üũ���� �س�����)

        //GameManager1.EndGame(); //�й�uiȣ��

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
            WaveSpawner.EnemiesAlive--;
            //Destroy(gameObject);
            EndPath(); //EndPath ()ȣ��
            return;
        }

        wavepointIndex++; //��������Ʈ ����������ȣ ���ϱ�(��������)
        target = Waypoints.points[wavepointIndex]; // Waypoints�� wavepointIndex(��������Ʈ ��������)�� target�� ����

    }

    void EndPath()
    {
        
        PlayerStats.Heart-=10; //��Ʈ -1�� ����
        Destroy(gameObject); //������Ʈ �ı�
        this.enabled = false;
    }
    void VicGame()
    {
        
        // Debug.Log("Game Over!");
        SceneManager.LoadScene("Victory Screen");
        //Time.timeScale = 0f;     // ���� �ð��� �����.(pause���)
        //VictoryPOP_UP.SetActive(true); // �й�â Ȱ��ȭ(üũ���� �س�����)

    }
}
