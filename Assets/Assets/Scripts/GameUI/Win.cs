using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] private Button mainMenu;
    [SerializeField] private Button nextLvl;

    private void Start()
    {
        // Подписываемся на события кнопок
        mainMenu.onClick.AddListener(MainMenu);
        nextLvl.onClick.AddListener(NextLvl);
    }
    private void MainMenu()
    {
        // Запускаем время
        Time.timeScale = 1f;
        // Возвращаемся в меню
        SceneManager.LoadScene(0);
    }
    private void NextLvl()
    {
        // Запускаем время
        Time.timeScale = 1f;
        // Переходим на следующий уровень
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLvl") / 3 + 1);
    }
}
