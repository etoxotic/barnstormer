using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartMenu
{
    public class FollowPoint : MonoBehaviour
    {
        // Этот скрипт создан для плавного перемещения камеры по меню
        [SerializeField] private Transform targetPoint; // точка, в которую нужно переместить камеру
        [Range(0f, 0.1f)] [SerializeField] private float smoothSpeed; // скорость, с которой происходит перемещение
        void Update()
        {
            if (transform.position != targetPoint.position) // Если координаты точек не совпадают
            {
                transform.position = Vector3.Lerp(transform.position, targetPoint.position, smoothSpeed); // Плавно премещаем камеру в нужую точку

                if ((targetPoint.position - transform.position).magnitude < 0.1f) // Если координаты почти совпадают
                    transform.position = targetPoint.position; // Устонавливаем камеру в позицию
            }
        }
    }
}
