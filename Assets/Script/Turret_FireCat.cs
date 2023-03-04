using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_FireCat : MonoBehaviour
{
    public Transform target;
    public float range = 15f; //Ÿ�� ��Ÿ�
    public float fireRate = 1f; // ��Ÿ�� �ð�
    private float fireCountdown = 0f; //��Ÿ�� ������

    public string enemyTag = "Enemy"; //Enemy �±�
    public Transform partToRotate; // partToRotate ��ȯ ��Ű�� ��� Cota Tower ���� ��� Cota Tower �� ȸ����
    public float turnSpeed = 10f; //ȸ���ӵ�
    public GameObject ArrowPrefab; //��ü ������ ����(��ü���� �̸��� ���ǻ� bullet���� �ϰ���)
    public Transform firePoint; //��ü �߻� ����Ʈ


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // 0.5�� ���� �ݺ� �Ѵ�.
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);// tag�� �±� �� ���� ������Ʈ�� ��ȯ�մϴ�.
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

        if (nearestEnemy != null && shortesDistance <= range) // ����� ���� null�� �ƴϰų� ���� �Ÿ��ȿ� ���� ���
        {
            target = nearestEnemy.transform; // ����� ���� �켱���� Ÿ���̵ȴ�.
        }
        else //�ƴҰ��
        {
            target = null; // Ÿ���� ����
        }
    }

    void Update()
    {
        if (target == null)
            return;
        Vector3 dir = target.position - transform.position; // Ÿ�� ������ - Ʈ������ ������ = ����3�� dir ��
        Quaternion lookRotation = Quaternion.LookRotation(-dir);//lookRotation() �Լ��� ������ǥ�� �� �����ǿ� ������ �ڱ� ��ġ���� �ڵ����� ��ȯ�ϴ� �Լ��Դϴ�.
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);//"x, y, z���� ȸ���� ������ ��ȯ�ض�!"

        if (fireCountdown <= 0f)//���� ��Ÿ�� ���Ұ� 0���� ���� ���
        {
            Shoot();
            fireCountdown = 1f / fireRate; //��Ÿ�� �ð��� �ʱ�ȭ
        }
        fireCountdown -= Time.deltaTime; //��Ÿ�� ������ �ʱ�ȭ
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
        Gizmos.color = Color.red; // ���� ����
        Gizmos.DrawWireSphere(transform.position, range);//������ Ÿ���� �Ÿ���ŭ ������ �׸���.
    }
}
