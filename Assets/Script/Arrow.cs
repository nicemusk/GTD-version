using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform target;

    public float speed;
    public int damage = 50; //���ݽ� ������ 50
    public float explosionradius = 0f;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFram = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFram)
        {
            HitTarget(); // ȣ��
            return;
        }

        transform.Translate(dir.normalized * distanceThisFram, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionradius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);


    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionradius);
        foreach (Collider collider in colliders)
        {
            if (gameObject.tag == "asdf")
            {
                Destroy(gameObject);
            }
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
               
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "StrangeBall")
        {
            speed = 0.5f;

        }
    }


    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        



        if (e != null)
        {
            e.TakeDamage(damage);
        }
        Boss2 j = enemy.GetComponent<Boss2>();
        if (j != null)
        {
            j.TakeDamage(damage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;//���� �� ����� ���� 
        Gizmos.DrawSphere(transform.position, explosionradius);//���� ���� 

    }
}
