using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billiard : MonoBehaviour
{
    public GameObject Ball; // Шар
    public float Power; // Сила удара по шару

    private Rigidbody rb; // Назначаем переменную для Rigidbody

    void Start()
    {
        rb = Ball.GetComponent<Rigidbody>(); // При старте получить данные о Rigidbody шара
    }

    void OnMouseDown() // По нажатию мыши
    {
        rb.AddForce(-transform.forward * Power, ForceMode.Impulse); // применяем силу к шару
    }
}
