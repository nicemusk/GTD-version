using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public float speed = 1f; //속도

    public int health = 100; //초기 체력

    public int value = 10; //적 파괴되면 올라가는 재화값 초기치 10 

    private Transform target;
    private int wavepointIndex = 0; //웨이포인트 인덱스(웨이포인트 나열순서 0)


    void Start()  // 타겟은 웨이포인츠의 포인트들
    {
        target = Waypoints.points[0];
    }

    // 데미지 받는
    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0) //health 가 0이 되면 Die()호출
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value; //사용자 머니 value값만큼 더하기
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject); //오브젝트 파괴
        

    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // 다음 웨이포인트로 이동
        if (Vector3.Distance(transform.position, target.position) <= 0.4f) //웨이포인트와 enemy 가 닿는 거리범위
        {
            GetNextWaypoint();
            transform.Rotate(0, -90, 0); //enemy가 y축으로 -90도회전
        }
    }

    private void GetNextWaypoint()
    {
        // 다음순서 웨이포인트가 없으면 오브젝트 파괴
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            //Destroy(gameObject);
            EndPath(); //EndPath ()호출
            return;
        }

        wavepointIndex++; //웨이포인트 나열순서번호 더하기(다음으로)
        target = Waypoints.points[wavepointIndex]; // Waypoints의 wavepointIndex(웨이포인트 나열순서)를 target에 대입

    }

    void EndPath()
    {
        WaveSpawner.EnemiesAlive--;
        PlayerStats.Heart-=5; //하트 -1씩 감소
        Destroy(gameObject); //오브젝트 파괴
  
    }
}
