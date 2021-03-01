using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace StartMenu
{
    public class LevelDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject[] stars;
        [SerializeField] private TMPro.TMP_Text text;
        [SerializeField] private Button button;

        public int lvl; // Номер уровня, за который отвечает кнопка
        public void StartLevel()  // Слушатель события нажатия кнопки
        {
            SceneManager.LoadScene(lvl + 1);
        }
        // Этот метод вызывается после создания кнопки
        public void Init(int lvl)
        {
            this.lvl = lvl;

            if (PlayerPrefs.HasKey("Level_" + lvl)) // Если этот уровень открыт
            {
                // Прячем все звезды кроме полученных
                for (int i = PlayerPrefs.GetInt("Level_" + lvl); i < 3; i++)
                {
                    stars[i].SetActive(false);
                }
            }
            else // Если уровень недоступен
            {
                button.interactable = false;  // Отключаем взаимодействие с кнопкой
                for (int i = 0; i < 3; i++) // Прячем все звезды
                {
                    stars[i].SetActive(false);
                }
            }

            text.text = lvl.ToString(); // Меняем текст
            button.onClick.AddListener(StartLevel); // Подписываем StartLevel на событие нажатия кнопки
        }
    }
}