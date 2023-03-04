using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_FireCat : MonoBehaviour
{
    public Transform target;
    public float range = 15f; //타워 사거리
    public float fireRate = 1f; // 쿨타임 시간
    private float fireCountdown = 0f; //쿨타임 감소율

    public string enemyTag = "Enemy"; //Enemy 태그
    public Transform partToRotate; // partToRotate 변환 시키는 대상 Cota Tower 넣을 경우 Cota Tower 가 회전함
    public float turnSpeed = 10f; //회전속도
    public GameObject ArrowPrefab; //물체 프리팹 생성(물체변수 이름은 편의상 bullet으로 하겠음)
    public Transform firePoint; //물체 발사 포인트


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // 0.5초 마다 반복 한다.
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);// tag로 태그 된 게임 오브젝트를 반환합니다.
        float shortesDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortesDistance)
            {
                shortesDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortesDistance <= range) // 가까운 적이 null이 아니거나 적이 거리안에 있을 경우
        {
            target = nearestEnemy.transform; // 가까운 적을 우선으로 타겟이된다.
        }
        else //아닐경우
        {
            target = null; // 타겟은 없다
        }
    }

    void Update()
    {
        if (target == null)
            return;
        Vector3 dir = target.position - transform.position; // 타겟 포지션 - 트랜스폼 포지션 = 벡터3의 dir 값
        Quaternion lookRotation = Quaternion.LookRotation(-dir);//lookRotation() 함수는 절대좌표로 그 포지션에 각도를 자기 위치에서 자동으로 변환하는 함수입니다.
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);//"x, y, z으로 회전한 각도를 반환해라!"

        if (fireCountdown <= 0f)//만약 쿨타임 감소가 0보다 적을 경우
        {
            Shoot();
            fireCountdown = 1f / fireRate; //쿨타임 시간을 초기화
        }
        fireCountdown -= Time.deltaTime; //쿨타임 감소율 초기화
    }

    void Shoot()
    {
        GameObject ArrowGO = Instantiate(ArrowPrefab, firePoint.position, firePoint.rotation);
        Arrow arrow = ArrowGO.GetComponent<Arrow>();

        if (arrow != null)
            arrow.Seek(target);
    }
        void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // 색은 빨강
        Gizmos.DrawWireSphere(transform.position, range);//지정된 타워의 거리만큼 원형을 그린다.
    }
}
