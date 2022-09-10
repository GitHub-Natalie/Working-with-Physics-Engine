using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public float TimeToExplosion; // ������ ������
    public float Power; // �������� ������
    public float Radius; // ������ ������

    void Update()
    {
        TimeToExplosion -= Time.deltaTime;

        if (TimeToExplosion <= 0)
        {
            Explosion();
            TimeToExplosion = 5;
        }
    }

    void Explosion()
    {
        Rigidbody[] Figures = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody Figure in Figures)
        {   // ���� ���������� �� ������ ������ �� ������ ������ �������
            if (Vector3.Distance(transform.position, Figure.transform.position) < Radius)
            {
                Vector3 direction = Figure.transform.position - transform.position; // ������ ����������� ����
                                                                                    // ����� ���� ���� ������, ����� ������ ��������� ����� � ��������� ������
                Figure.AddForce(direction.normalized * Power * (Radius - Vector3.Distance(transform.position, Figure.transform.position)), ForceMode.Impulse);
            }
        }
    }

}
