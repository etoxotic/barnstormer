using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Gears : MonoBehaviour
    {
        [SerializeField] private float inAngle; // Угол при котором шасси убраны
        [SerializeField] private float outAngle; // Угол, при котором шасси выдвинуты
        [SerializeField] private GameObject[] gears; // Сами шасси

        private float qurrentAngle; // Текущий угол
        private WheelCollider[] wheels; // Коллайдеры колес
        private Controls controls; // Система управления

        void Start()
        {
            // Заполняем массив колес
            wheels = new WheelCollider[3];
            for (int i = 0; i < 3; i++)
                wheels[i] = gears[i].GetComponent<WheelCollider>();

            // Устанавливаем начальный угол
            qurrentAngle = outAngle;

            // Получаем компонент управления
            controls = GetComponentInParent<Controls>();
        }

        void FixedUpdate()
        {
            // Выдвижение/задвижение шасси
            if (controls.GearsOut && qurrentAngle > outAngle)
            {
                qurrentAngle -= 1f;
                gears[0].transform.localRotation = Quaternion.Euler(0f, 0f, qurrentAngle);
                gears[1].transform.localRotation = Quaternion.Euler(0f, 0f, -qurrentAngle);
            }
            if (!controls.GearsOut && qurrentAngle < inAngle)
            {
                qurrentAngle += 1f;
                gears[0].transform.localRotation = Quaternion.Euler(0f, 0f, qurrentAngle);
                gears[1].transform.localRotation = Quaternion.Euler(0f, 0f, -qurrentAngle);
            }

            // Торможение
            if (controls.Breaks)
                for (int i = 0; i < 3; i++)
                    wheels[i].brakeTorque = 500f;
            else
                for (int i = 0; i < 3; i++)
                    wheels[i].brakeTorque = 0f;

            // Ускорение колесами
            for (int i = 0; i < 3; i++)
                wheels[i].motorTorque = 1000f * controls.Pull;

            // Поворот
            wheels[2].steerAngle = 45f * controls.Yaw;
        }
    }
}