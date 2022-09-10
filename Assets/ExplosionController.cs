using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public float TimeToExplosion; // Таймер взрыва
    public float Power; // Мощность взрыва
    public float Radius; // Радиус взрыва

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
        {   // если расстояние от центра взрыва до фигуры меньше радиуса
            if (Vector3.Distance(transform.position, Figure.transform.position) < Radius)
            {
                Vector3 direction = Figure.transform.position - transform.position; // Вектор направления силы
                                                                                    // чтобы сила была больше, когда объект находится ближе к эпицентру взрыва
                Figure.AddForce(direction.normalized * Power * (Radius - Vector3.Distance(transform.position, Figure.transform.position)), ForceMode.Impulse);
            }
        }
    }

}
