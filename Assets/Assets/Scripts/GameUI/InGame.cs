using UnityEngine.UI;
using UnityEngine;

public class InGame : MonoBehaviour
{
    public Quest.Quest quest;

    [SerializeField] private Text text;
    [SerializeField] private GameObject pauseMenu;

    private void Update()
    {
        // Если квест привязан (поидее должен быть привязан всегда, но вдруг что)
        if(quest)
        {
            // Обновляем таймер
            text.text = quest.Timer.ToString();
        }
        // Если нажали на esc
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // Останавливаем время
            Time.timeScale = 0f;
            // Включаем меню паузы
            pauseMenu.SetActive(true);
        }
    }
}
