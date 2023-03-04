using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2 : MonoBehaviour
{
    public float speed = 1f; //속도

    public int health = 500; //초기 체력

    public int value = 1000; //적 파괴되면 올라가는 재화값 초기치 10 
    
    private Transform target;
    private int wavepointIndex = 0; //웨이포인트 인덱스(웨이포인트 나열순서 0)
    public GameObject VictoryPOP_UP;

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
            WaveSpawner.EnemiesAlive--;
            Die();
        }
    }

    void Die()
    {
        
        Debug.Log("승리");
        VicGame();

        Destroy(gameObject); //오브젝트 파괴
       

        Time.timeScale = 0f;     // 게임 시간을 멈춘다.(pause기능)
        //DefeatPOP_UP.SetActive(true); // 패배창 활성화(체크해제 해놓은거)

        //GameManager1.EndGame(); //패배ui호출

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
            WaveSpawner.EnemiesAlive--;
            //Destroy(gameObject);
            EndPath(); //EndPath ()호출
            return;
        }

        wavepointIndex++; //웨이포인트 나열순서번호 더하기(다음으로)
        target = Waypoints.points[wavepointIndex]; // Waypoints의 wavepointIndex(웨이포인트 나열순서)를 target에 대입

    }

    void EndPath()
    {
        
        PlayerStats.Heart-=10; //하트 -1씩 감소
        Destroy(gameObject); //오브젝트 파괴
        this.enabled = false;
    }
    void VicGame()
    {
        
        // Debug.Log("Game Over!");
        SceneManager.LoadScene("Victory Screen");
        //Time.timeScale = 0f;     // 게임 시간을 멈춘다.(pause기능)
        //VictoryPOP_UP.SetActive(true); // 패배창 활성화(체크해제 해놓은거)

    }
}
