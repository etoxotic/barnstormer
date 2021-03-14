using UnityEngine;

// ��� ������� ������ ��� ������ (���� ����)
// ��� �������� ���������� ������ � ���������, ����� ����� ��������� �� ����, 
// ������� ���� ������ ����� �������� �� ������, ���������� � ���������� ���������.
// ����� � ������ ������� ����� ����������� ������� ������ � ����� ����������� �
// ���������� ��� ����������������� ����������.
public class Quest : MonoBehaviour
{
    private Checkpoint[] points;
    void Start()
    {
        points = gameObject.GetComponentsInChildren<Checkpoint>();
        foreach (var point in points)
        {
            print(point.gameObject.name);
        }
    }
}
