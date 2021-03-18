using UnityEngine.UI;
using UnityEngine;

public class InGame : MonoBehaviour
{
    public Quest.Quest quest;

    [SerializeField] private Text text;
    [SerializeField] private GameObject pauseMenu;

    private void Update()
    {
        // ���� ����� �������� (������ ������ ���� �������� ������, �� ����� ���)
        if(quest)
        {
            // ��������� ������
            text.text = quest.Timer.ToString();
        }
        // ���� ������ �� esc
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // ������������� �����
            Time.timeScale = 0f;
            // �������� ���� �����
            pauseMenu.SetActive(true);
        }
    }
}
