using UnityEngine;

namespace Quest
{
    // ������ ������ ����� �������������� ��� ����� �������� �������� ����� ����������.
    // ��������� ��������� ����� �� ������������� ������������ ������ - ��������!  :)
    public class Checkpoint : MonoBehaviour
    {
        public int id;
        public void CreateNextCheckpoint()
        {
            // ������� ����� ��������
            GameObject nextCheckpoint = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            // ���� ��� ����� id
            nextCheckpoint.GetComponent<Checkpoint>().id = id + 1;
            // ���� ��� ���������� ���
            nextCheckpoint.name = "Checkpoint " + (id + 1);
        }
    }
}