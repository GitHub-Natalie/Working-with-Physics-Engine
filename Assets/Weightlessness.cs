using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weightlessness : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // ��� ��������� � �������
    {
        other.attachedRigidbody.useGravity = false; // �������� ����, � �������� ���������� ���������, ��������� Use Gravity
    }

    private void OnTriggerExit(Collider other) // ��� ������ �� ��������
    {
        other.attachedRigidbody.useGravity = true; // �������� ����, � �������� ���������� ���������, ��������� Use Gravity
    }
}
