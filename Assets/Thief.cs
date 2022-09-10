using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public float timeToDisappear; // Время до исчезновения Вора
    public float Power; // Сила удара
    public bool punch = false; // Удар Супермена 

    private Rigidbody Trb; // Назначаем отдельную переменную для Rigidbody Вора

    void Start()
    {
        Trb = GetComponent<Rigidbody>(); // При старте записываем Rigidbody Вора в переменную
        Trb.isKinematic = true; // Включаем Вору IsKinematic (для корректного движения)
    }

    void OnCollisionEnter(Collision collision) // Проверяем, столкнулся ли Вор с Суперменом, при столкновении
    {
        Trb.isKinematic = false; // отключаем Вору isKinematic (для применения силы)
        punch = true; // Событие "Удар Супермена" произошло
    }

    void FixedUpdate()
    {
        if (punch) // Если Супермен нанес удар, то
        {
            Trb.AddForce(-transform.forward * Power, ForceMode.Impulse); // Наносим Вору удар (направление удара * сила удара * применение силы)
        }
    }

    void Update()
    {
        if (punch) // Если Супермен нанес удар, то
        {
            timeToDisappear -= Time.deltaTime; // запускаем таймер, по окончании которого Вор исчезнет

            if (timeToDisappear <= 0) // Если время таймера меньше либо равно нулю, то 
            {
                Destroy(gameObject); // удаляем Вора со сцены
            }
        }
    }
}
