using UnityEngine;
using UnityEngine.Events;

// ��� ������� ������ ��� ������ (���� ����)
// ��� �������� ���������� ������ � ���������, ����� ����� ��������� �� ����, 
// ������� ���� ������ ����� �������� �� ������, ���������� � ���������� ���������.
// ����� � ������ ������� ����� ����������� ������� ������ � ����� ����������� �
// ���������� ��� ����������������� ����������.
public class Quest : MonoBehaviour
{
    [SerializeField] private GameObject ringPrefab;

    private Checkpoint[] points;
    private Ring[] rings;
    private int currentRing = 0;

    private UnityEvent OnStart;
    private UnityEvent OnFinish;

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
        // �������������� �� ������� ����� � ������ ������
        rings[0].OnEnter.AddListener(RingEnterHandler);
    }

    private void RingEnterHandler()
    {
        // ������������ �� ������� ����� � ������� ������
        rings[currentRing].OnEnter.RemoveListener(RingEnterHandler);

        //      ������ ������������ ������ ������
        // ���� �� ������ � ������ ������
        if (currentRing == 0)
        {
            // �������� ������� ������ ���� ����
            OnStart.Invoke();
        }
        // ���� �� ����� � ��������� ������
        if (currentRing == rings.Length - 1)
        {
            // �������� ������� �������� ���� ����
            OnFinish.Invoke();
        }


        //    ������ ���������� � ���, ��� �������� �����
        // ���� �� ������ � ����� ������ ����� ���������� � ��������������
        if(currentRing < rings.Length - 2)
        {
            // �������� ������ ����� ����
            rings[currentRing + 2].gameObject.SetActive(true);
            // ���������� ���������
            rings[currentRing + 1].Activate(false);
            // ������������� �� ������ ����� � �������� ������
            rings[currentRing].OnEnter.AddListener(RingEnterHandler);
        }
        // ���� ������ � ������������� ������
        if(currentRing == rings.Length - 2)
        {
            // ���������� ��������� c �������� ������
            rings[currentRing + 1].Activate(true);
        }
        currentRing = currentRing + 1;
    }
}
