using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    public float timeToOffIsKinematic = 5; // ����� �� ������������ ����
    public bool punch = false; // ���� ��������� 

    private Rigidbody Srb; // ��������� ��������� ���������� ��� Rigidbody ���������

    void Start()
    {
        Srb = GetComponent<Rigidbody>(); // ��� ������ ���������� Rigidbody ��������� � ����������
        Srb.isKinematic = false; // ��������� IsKinematic (��� ��������� �����)
    }
    private void OnTriggerEnter(Collider other) // ���� �������� ����� � �������, ��
    {
        Srb.isKinematic = true; // �������� ��������� IsKinematic (��� ����������� ��������)
        punch = true;
    }

    void Update()
    {
        if (punch) // ���� �������� ����� ����, ��
        {
            timeToOffIsKinematic -= Time.deltaTime; // ��������� ������, �� ��������� �������� ��� ��������

            if (timeToOffIsKinematic <= 0) // ���� ����� ������� ������ ���� ����� ����, �� 
            {
                Srb.isKinematic = false; // ��������� IsKinematic (��� ��������� �����)
                timeToOffIsKinematic = 5;
                punch = false;
            }
        }
    }
}
