using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] private Button mainMenu;
    [SerializeField] private Button nextLvl;

    private void Start()
    {
        // ������������� �� ������� ������
        mainMenu.onClick.AddListener(MainMenu);
        nextLvl.onClick.AddListener(NextLvl);
    }
    private void MainMenu()
    {
        // ��������� �����
        Time.timeScale = 1f;
        // ������������ � ����
        SceneManager.LoadScene(0);
    }
    private void NextLvl()
    {
        // ��������� �����
        Time.timeScale = 1f;
        // ��������� �� ��������� �������
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLvl") / 3 + 1);
    }
}
