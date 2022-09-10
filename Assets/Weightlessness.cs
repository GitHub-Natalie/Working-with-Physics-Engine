using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weightlessness : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // При попадании в триггер
    {
        other.attachedRigidbody.useGravity = false; // твердому телу, к которому прикреплен коллайдер, отключаем Use Gravity
    }

    private void OnTriggerExit(Collider other) // При выходе из триггера
    {
        other.attachedRigidbody.useGravity = true; // твердому телу, к которому прикреплен коллайдер, вкллючаем Use Gravity
    }
}
