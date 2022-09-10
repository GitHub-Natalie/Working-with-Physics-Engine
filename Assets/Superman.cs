using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    public float timeToOffIsKinematic = 5; // Время до исчезновения Вора
    public bool punch = false; // Удар Супермена 

    private Rigidbody Srb; // Назначаем отдельную переменную для Rigidbody Супермена

    void Start()
    {
        Srb = GetComponent<Rigidbody>(); // При старте записываем Rigidbody Супермена в переменную
        Srb.isKinematic = false; // отключаем IsKinematic (для нанесения Удара)
    }
    private void OnTriggerEnter(Collider other) // Если Супермен зашел в триггер, то
    {
        Srb.isKinematic = true; // включаем Супермену IsKinematic (для корректного движения)
        punch = true;
    }

    void Update()
    {
        if (punch) // Если Супермен нанес удар, то
        {
            timeToOffIsKinematic -= Time.deltaTime; // запускаем таймер, по окончании которого Вор исчезнет

            if (timeToOffIsKinematic <= 0) // Если время таймера меньше либо равно нулю, то 
            {
                Srb.isKinematic = false; // отключаем IsKinematic (для нанесения Удара)
                timeToOffIsKinematic = 5;
                punch = false;
            }
        }
    }
}
