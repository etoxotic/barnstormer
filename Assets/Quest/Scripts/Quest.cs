using UnityEngine;

// ��� ������� ������ ��� ������ (���� ����)
// ��� �������� ���������� ������ � ���������, ����� ����� ��������� �� ����, 
// ������� ���� ������ ����� �������� �� ������, ���������� � ���������� ���������.
// ����� � ������ ������� ����� ����������� ������� ������ � ����� ����������� �
// ���������� ��� ����������������� ����������.
public class Quest : MonoBehaviour
{
    private Transform[] points;
    void Start()
    {
        points = gameObject.GetComponentsInChildren<Transform>();
        foreach (var point in points)
        {
            print(point.gameObject.name);
        }
    }
}
