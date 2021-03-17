using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Gears : MonoBehaviour
    {
        [SerializeField] private float inAngle; // ���� ��� ������� ����� ������
        [SerializeField] private float outAngle; // ����, ��� ������� ����� ���������
        [SerializeField] private GameObject[] gears; // ���� �����

        private float qurrentAngle; // ������� ����
        private WheelCollider[] wheels; // ���������� �����
        private Controls controls; // ������� ����������

        void Start()
        {
            // ��������� ������ �����
            wheels = new WheelCollider[3];
            for (int i = 0; i < 3; i++)
                wheels[i] = gears[i].GetComponent<WheelCollider>();

            // ������������� ��������� ����
            qurrentAngle = outAngle;

            // �������� ��������� ����������
            controls = GetComponentInParent<Controls>();
        }

        void FixedUpdate()
        {
            // ����������/���������� �����
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

            // ����������
            if (controls.Breaks)
                for (int i = 0; i < 3; i++)
                    wheels[i].brakeTorque = 500f;
            else
                for (int i = 0; i < 3; i++)
                    wheels[i].brakeTorque = 0f;

            // ��������� ��������
            for (int i = 0; i < 3; i++)
                wheels[i].motorTorque = 1000f * controls.Pull;

            // �������
            wheels[2].steerAngle = 45f * controls.Yaw;
        }
    }
}