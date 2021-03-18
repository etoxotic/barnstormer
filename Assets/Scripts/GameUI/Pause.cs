using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Button restart;
    [SerializeField] private Button quit;

    private void Start()
    {
        // ������������ �� ������� ������� ������
        continueButton.onClick.AddListener(Continue);
        restart.onClick.AddListener(Restart);
        quit.onClick.AddListener(Quit);
    }
    private void Continue()
    {
        // ����� ��������� �����
        Time.timeScale = 1f;
        // ������ ���� �����
        gameObject.SetActive(false);
    }
    private void Restart()
    {
        // ����� ��������� �����
        Time.timeScale = 1f;
        // ������������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Quit()
    {
        // ����� ��������� �����
        Time.timeScale = 1f;
        // ������������ � ����
        SceneManager.LoadScene(0);
    }
}
