using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWayThief : MonoBehaviour
{
    public MovementWay MyPath; // ������������ ����
    public float speed; // �������� ��������

    private IEnumerator<Transform> pointInPath; // �������� �����

    void Start()
    {
        if (MyPath == null) // ��������, ���������� �� �� ����
        {
            Debug.Log("�� ������ ����");
            return;
        }

        pointInPath = MyPath.GetNextPathPoint(); // ��������� � �������� GetNextPathPoint
        pointInPath.MoveNext(); // ��������� ��������� ����� � ����

        if (pointInPath.Current == null) // ��������, ���� �� ����� � ������� ���������
        {
            Debug.Log("� ��������� ���� ����������� ����� ��������");
            return;
        }

        transform.position = pointInPath.Current.position; // ������ ������ ������ �� ��������� ����� ����
        transform.LookAt(pointInPath.Current.position); // ������ ������ �������� � ������� ��������
    }

    void Update()
    {
        if (pointInPath == null || pointInPath.Current == null) // �������� ���������� ����
        {
            return; // �����, ������ ��� ���� ���
        }

        transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed); // ������� ������ � ��������� �����
        transform.LookAt(pointInPath.Current.position);

        if (transform.position == pointInPath.Current.position) // ���� ������ ����� �� �����, � ������� ��������, ��
        {
            pointInPath.MoveNext(); // ����� �������� � ��������� ����� � ����
        }
    }

    void OnCollisionEnter(Collision collision) // ���������, ���������� �� ��� � ����������, ��� ������������
    {
        MyPath = null; // ������� ������� ����, 
        pointInPath = null; // ��������� �����
        speed = 0; // � �������� �������� (��� ����������� �������)
    }
}
