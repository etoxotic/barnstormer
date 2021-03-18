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
        // Подписывемся на события нажатия кнопок
        continueButton.onClick.AddListener(Continue);
        restart.onClick.AddListener(Restart);
        quit.onClick.AddListener(Quit);
    }
    private void Continue()
    {
        // Вновь запускаем время
        Time.timeScale = 1f;
        // Прячем меню паузы
        gameObject.SetActive(false);
    }
    private void Restart()
    {
        // Вновь запускаем время
        Time.timeScale = 1f;
        // Перезапускаем сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Quit()
    {
        // Вновь запускаем время
        Time.timeScale = 1f;
        // Отправляемся в меню
        SceneManager.LoadScene(0);
    }
}
