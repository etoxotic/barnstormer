using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private Controls controls;
    [SerializeField] private float enginePower; // �������� ���������
    [SerializeField] private float rollPower; // �������� �����
    [SerializeField] private float pitchPower; // �������� �������
    [SerializeField] private float yawPower; // �������� ��������
    [SerializeField] private float tailPower; // �������� ���������� ��������
    [SerializeField] private float liftPower; // �������� ������ �������
    [SerializeField] private float dragPower; // �������� ���� ������

    private void Awake()
    {
        controls = GetComponent<Controls>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // ��������� ������ � Controls
        float pull = controls.Pull;
        float pitch = controls.Pitch;
        float roll = controls.Roll;
        float yaw = controls.Yaw;

        //���������� ����������, ������� ����� ����� �������������� ��� ��������
        // ������� �������� �������� �� ������������ ��������� ��������
        float sqrSpeed = Mathf.Pow(Vector3.ProjectOnPlane(rb.velocity, transform.right).magnitude, 2);
        // �������� ������� (����� ����� ��������)
        float t = Time.fixedDeltaTime;
        // ����������� ��� ����
        ForceMode f = ForceMode.Acceleration;

        // ���������� ��� � �������� ��������
        // ��������� ���������� (������ ���� ����� ����������� ��������)
        rb.AddForce(transform.forward * pull * enginePower * t, f);
        // ��������� ���� (����, ������������ �����, ������� �� �������� � ���� �����)
        rb.AddForce(transform.up * LiftCoefficient() * sqrSpeed * t, f);
        // ���� ������������� ������� (����, ������������ ������ ������� ��������, ������� �� ���� ����� � ��������)
        rb.AddForce(-rb.velocity.normalized * DragCoefficient() * sqrSpeed * t, f);
        // ���� (������ �������� ����� ����������� ��������, ��������� �� �������� ��)
        rb.AddTorque(-transform.forward * roll * rollPower * sqrSpeed * t, f);
        // ������ (������ �������� ����� ���������� ��� ��������, ������� �� ��������)
        rb.AddTorque(transform.right * pitch * pitchPower * sqrSpeed * t, f);
        // �������� (������ �������� ����� ������������ ��� ��������, ������� �� ��������)
        rb.AddTorque(-transform.up * yaw * yawPower * sqrSpeed * t, f);
        // ������ �������� (������ ��������, ����������������� ���������� ��� �������� � ��� ��������)
        rb.AddTorque((Vector3.Cross(transform.forward, rb.velocity)).normalized * Mathf.Pow(rb.velocity.magnitude, 2) * tailPower * t);
    }
    private float LiftCoefficient() // ������� ��� ��������� ������������ ��������� ����, ������� ������� �� ���� ����� ��������
    {
        // ��������� ���� �����
        // ��� ������ �������� ������� �������� �� ������������ ��������� ��������
        // � ������ ���������� �������� �� �� ��������� ��������� ��������� ���� ��� ����������
        Vector3 velToPlane = Vector3.ProjectOnPlane(rb.velocity, transform.right);

        // ����� ������� ���� �����, ��� ���� ����� ������������ �������� � ������������ ���� ��������
        // ��������� ���� ���� ����� �������� �� ���������� �������� ������� ��������� ����
        float angle = Vector3.SignedAngle(velToPlane, transform.forward, -transform.right);
        
        // res - �������������� �����������
        float res = 0f;

        // ��� ���������� ���� ����� ����������� ������������������� ���� �����
        if (Mathf.Abs(angle) < 15f)
            res = angle;
        // ��� ���������� ����������� ����� ������
        else if (Mathf.Abs(angle) < 30f)
            res = Mathf.Sign(angle) * (30f - Mathf.Abs(angle));
        // � ���������� ������ ��� ����������� ����� ����� ����������� ����� 0
        else
            res = 0f;
        // ����� �� �������� ����������� �� �������� ��������� ����
        return res * liftPower;
    }
    private float DragCoefficient()
    {
        // ��������� ���� �����
        // ��� ������ �������� ������� �������� �� ������������ ��������� ��������
        // � ������ ���������� �������� �� �� ��������� ��������� ��������� ���� ��� ����������
        Vector3 velToPlane = Vector3.ProjectOnPlane(rb.velocity, transform.right);

        // ����� ������� ���� �����, ��� ���� ����� ������������ �������� � ������������ ���� ��������
        // ��������� ���� ���� ����� �������� �� ���������� �������� ������� ��������� ����
        float angle = Vector3.SignedAngle(velToPlane, transform.forward, -transform.right);

        // res - �������������� �����������
        float res = 0f;

        // � ���������� ������ ��� ��������� ����� ����� ����������� ��������� �������� 1
        if (Mathf.Abs(angle) < 15f)
            res = 1f;
        // � ��� ���������� ���������� �� 15
        else
            res = 15f;

        // ����� �������� �� �������� ���� ������
        return res * dragPower;
    }
}
