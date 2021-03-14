using UnityEngine;
using UnityEngine.Events;

namespace Quest
{
    // ���� ������ ����� �� ������ � ������ ��� �������� ��������� Quest-�
    public class Ring : MonoBehaviour
    {

        public UnityEvent OnEnter;
        [SerializeField] private Material activeMaterial;
        [SerializeField] private Material finishMaterial;

        private void OnTriggerEnter(Collider other)
        {
            // ��� ����� ���������� � ������ ���������� ������ OnEnter
            OnEnter.Invoke();
        }
        public void Activate(bool isFinish)
        {
            // �������� �������� ���� ������
            if (isFinish)
            {
                GetComponent<MeshRenderer>().material = finishMaterial;
            }
            else
            {
                GetComponent<MeshRenderer>().material = activeMaterial;
            }
        }
    }
}