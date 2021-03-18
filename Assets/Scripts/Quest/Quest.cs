using UnityEngine;
using UnityEngine.Events;
namespace Quest
{
    // ��� ������� ������ ��� ������ (���� ����)
    // ��� �������� ���������� ������ � ���������, ����� ����� ��������� �� ����, 
    // ������� ���� ������ ����� �������� �� ������, ���������� � ���������� ���������.
    // ����� � ������ ������� ����� ����������� ������� ������ � ����� ����������� �
    // ���������� ��� ����������������� ����������.
    public class Quest : MonoBehaviour
    {
        [SerializeField] private GameObject ringPrefab;
        [SerializeField] private float threeStars;
        [SerializeField] private float twoStars;

        private Checkpoint[] points;
        private Ring[] rings;
        private int currentRing = 0;
        private bool questInProgress = false;

        public UnityEvent OnStart = new UnityEvent();
        public UnityEvent OnFinish = new UnityEvent();
        public float Timer { get; private set; } = 0;
        public int Stars { get; private set; } = 1;

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

            // ������� ��������� ������ ��� ����� ������
            rings[0].Activate(false);
            for (int i = 2; i < rings.Length; i++)
            {
                rings[i].gameObject.SetActive(false);
            }

            // � �������� ������ � ���������� �����������
            for (int i = 1; i < rings.Length; i++)
            {
                rings[i].transform.LookAt(rings[i - 1].transform);
            }
        }

        private void RingEnterHandler()
        {
            // ������������ �� ������� ����� � ������� ������
            rings[currentRing].OnEnter.RemoveListener(RingEnterHandler);
            rings[currentRing].gameObject.SetActive(false);

            //      ������ ������������ ������ ������
            // ���� �� ������ � ������ ������
            if (currentRing == 0)
            {
                // ��������� ������
                questInProgress = true;
                // �������� ������� ������ ���� ����
                OnStart.Invoke();
            }
            // ���� �� ����� � ��������� ������
            if (currentRing == rings.Length - 1)
            {
                // ������������� ������
                questInProgress = false;
                // ���������� ���������� �����
                if (Timer < threeStars)
                    Stars = 3;
                else if (Timer < twoStars)
                    Stars = 2;
                else
                    Stars = 1;
                // �������� ������� �������� ���� ����
                OnFinish.Invoke();
            }


            //    ������ ���������� � ���, ��� �������� �����
            // ���� �� ������ � ����� ������ ����� ���������� � ��������������
            if (currentRing < rings.Length - 2)
            {
                // �������� ������ ����� ����
                rings[currentRing + 2].gameObject.SetActive(true);
                // ���������� ���������
                rings[currentRing + 1].Activate(false);
                // ������������� �� ������ ����� � ��������� ������
                rings[currentRing + 1].OnEnter.AddListener(RingEnterHandler);
            }
            // ���� ������ � ������������� ������
            if (currentRing == rings.Length - 2)
            {
                // ���������� ��������� c �������� ������
                rings[currentRing + 1].Activate(true);
                // ������������� �� ������ ����� � ��������� ������
                rings[currentRing + 1].OnEnter.AddListener(RingEnterHandler);
            }
            // �������� � ���������� ������
            currentRing = currentRing + 1;
        }

        private void Update()
        {
            // ���� ����� ��� �������
            if(questInProgress)
                // ����������� ��������� �������
                Timer += Time.deltaTime;
        }
    }
}