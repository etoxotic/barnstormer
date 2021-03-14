using UnityEngine;

// ��� ������� ������ ��� ������ (���� ����)
// ��� �������� ���������� ������ � ���������, ����� ����� ��������� �� ����, 
// ������� ���� ������ ����� �������� �� ������, ���������� � ���������� ���������.
// ����� � ������ ������� ����� ����������� ������� ������ � ����� ����������� �
// ���������� ��� ����������������� ����������.
public class Quest : MonoBehaviour
{
    [SerializeField] private GameObject ringPrefab;
    [SerializeField] private Material activeMaterial;
    [SerializeField] private Material unactiveMaterial;

    private Checkpoint[] points;
    private Ring[] rings;
    private int currentRing;

    private void Start()
    {
        // �������� ��� ���������
        points = gameObject.GetComponentsInChildren<Checkpoint>();
        // ������� ������ ��� �����
        rings = new Ring[points.Length];
        // ������ ������
        for (int i = 0; i < points.Length; i++) 
        {
            // �������� i-��� ��������
            Checkpoint point = points[i]; 
            // ������������� ������ �� ����� ���������
            GameObject ring = Instantiate(ringPrefab, point.transform.position, point.transform.rotation, transform);
            // ������ �������� ������
            ring.name = "Ring " + point.id;
            // ��������� ������ � ������ �����
            rings[i] = ring.GetComponent<Ring>();
            //������� ��������
            Destroy(point.gameObject);
        }
        rings[0].OnEnter.AddListener(RingEnterHandler);
    }

    private void RingEnterHandler()
    {

    }
}
