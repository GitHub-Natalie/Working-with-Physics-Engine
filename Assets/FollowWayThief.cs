using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWayThief : MonoBehaviour
{
    public MovementWay MyPath; // Используемый путь
    public float speed; // Скорость движения

    private IEnumerator<Transform> pointInPath; // Проверка точек

    void Start()
    {
        if (MyPath == null) // Проверка, прикрепили ли мы путь
        {
            Debug.Log("Не выбран путь");
            return;
        }

        pointInPath = MyPath.GetNextPathPoint(); // Обращение к корутину GetNextPathPoint
        pointInPath.MoveNext(); // Получение следующей точки в пути

        if (pointInPath.Current == null) // Проверка, есть ли точка к которой двигаться
        {
            Debug.Log("В выбранном пути отсутствуют точки движения");
            return;
        }

        transform.position = pointInPath.Current.position; // Объект должен встать на стартовую точку пути
        transform.LookAt(pointInPath.Current.position); // Объект должен смотреть в сторону движения
    }

    void Update()
    {
        if (pointInPath == null || pointInPath.Current == null) // Проверка отсутствия пути
        {
            return; // Выход, потому что пути нет
        }

        transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed); // Двигать объект к следующей точке
        transform.LookAt(pointInPath.Current.position);

        if (transform.position == pointInPath.Current.position) // Если объект дошел до точки, к которой двигался, то
        {
            pointInPath.MoveNext(); // пусть движется к следующей точке в пути
        }
    }

    void OnCollisionEnter(Collision collision) // проверяем, столкнулся ли Вор с Суперменом, при столкновении
    {
        MyPath = null; // Убираем Объекту путь, 
        pointInPath = null; // следующую точку
        speed = 0; // и скорость движения (для корректного падения)
    }
}
