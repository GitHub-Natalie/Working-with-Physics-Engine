using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public float timeToDisappear; // ����� �� ������������ ����
    public float Power; // ���� �����
    public bool punch = false; // ���� ��������� 

    private Rigidbody Trb; // ��������� ��������� ���������� ��� Rigidbody ����

    void Start()
    {
        Trb = GetComponent<Rigidbody>(); // ��� ������ ���������� Rigidbody ���� � ����������
        Trb.isKinematic = true; // �������� ���� IsKinematic (��� ����������� ��������)
    }

    void OnCollisionEnter(Collision collision) // ���������, ���������� �� ��� � ����������, ��� ������������
    {
        Trb.isKinematic = false; // ��������� ���� isKinematic (��� ���������� ����)
        punch = true; // ������� "���� ���������" ���������
    }

    void FixedUpdate()
    {
        if (punch) // ���� �������� ����� ����, ��
        {
            Trb.AddForce(-transform.forward * Power, ForceMode.Impulse); // ������� ���� ���� (����������� ����� * ���� ����� * ���������� ����)
        }
    }

    void Update()
    {
        if (punch) // ���� �������� ����� ����, ��
        {
            timeToDisappear -= Time.deltaTime; // ��������� ������, �� ��������� �������� ��� ��������

            if (timeToDisappear <= 0) // ���� ����� ������� ������ ���� ����� ����, �� 
            {
                Destroy(gameObject); // ������� ���� �� �����
            }
        }
    }
}
