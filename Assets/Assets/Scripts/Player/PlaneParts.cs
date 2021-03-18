using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlaneParts : MonoBehaviour
    {
        [SerializeField] private GameObject elevator; // Руль высоты
        [SerializeField] private GameObject rudder; // Руль направления
        [SerializeField] private GameObject propeller; // Пропеллер
        [SerializeField] private float rotationSpeed; // Скорость вращения пропеллера

        private Controls controls;
        private float elevatorAngle;
        private float rudderAngle;

        private void Start()
        {
            controls = GetComponentInParent<Controls>();
        }

        void Update()
        {
            elevatorAngle = Mathf.Lerp(elevatorAngle, -controls.Pitch * 20f, 0.5f);
            rudderAngle = Mathf.Lerp(rudderAngle, controls.Yaw * 20f, 0.01f);

            elevator.transform.localRotation = Quaternion.Euler(elevatorAngle, 0, 0);
            rudder.transform.localRotation = Quaternion.Euler(0, rudderAngle, 0);
            propeller.transform.localRotation *= Quaternion.Euler(0, 0, controls.Pull * rotationSpeed * Time.deltaTime);
        }
    }
}