using UnityEngine;

public class Controls : MonoBehaviour
{
    public float Yaw { get; private set; } = 0f; // ��������
    public float Roll { get; private set; } = 0f; // ����
    public float Pitch { get; private set; } = 0f; // ������
    public float Pull { get; private set; } = 0f; // ����
    public bool GearsOut { get; private set; } = true;// �����
    public bool Breaks { get; private set; } = false;// �������

    private void Update()
    {
        // ���������� ��������� �� ������� Q � E
        Yaw = 0; 
        if (Input.GetKey(KeyCode.Q))
            Yaw += 1;
        if (Input.GetKey(KeyCode.E))
            Yaw -= 1;

        // ���������� �������� �� ������� W � S
        Pitch = Input.GetAxis("Vertical");

        // ���������� ������ �� ������� A � D
        Roll = Input.GetAxis("Horizontal");

        // ���������� ����� �� LeftShift � LeftCtrl
        if (Input.GetKey(KeyCode.LeftShift)) 
            Pull = Mathf.Clamp(Pull + Time.deltaTime, 0f, 1f);
        if (Input.GetKeyDown(KeyCode.LeftCommand))
            Pull = Mathf.Clamp(Pull - Time.deltaTime, 0f, 1f);

        // ������ � ������ ����� �� ������� G
        if (Input.GetKeyDown(KeyCode.G))
            GearsOut = !GearsOut;

        // ���������� ���������� ��� ������� ���� � ������� ������� ���������� ���� LeftCtrl
        if (Input.GetKey(KeyCode.LeftCommand) && Pull == 0f)
            Breaks = true;
        else
            Breaks = false;
    }
}
