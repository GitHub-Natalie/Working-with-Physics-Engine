using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billiard : MonoBehaviour
{
    public GameObject Ball; // ���
    public float Power; // ���� ����� �� ����

    private Rigidbody rb; // ��������� ���������� ��� Rigidbody

    void Start()
    {
        rb = Ball.GetComponent<Rigidbody>(); // ��� ������ �������� ������ � Rigidbody ����
    }

    void OnMouseDown() // �� ������� ����
    {
        rb.AddForce(-transform.forward * Power, ForceMode.Impulse); // ��������� ���� � ����
    }
}
