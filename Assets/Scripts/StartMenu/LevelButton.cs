using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private GameObject[] stars;
        private Text text;
        private Button button;
        private SaveGame save;
        private int id;

        public void Init(int id)
        {
            // Принимаем уровень, за который отвечает кнопка
            this.id = id;
        }

        private void Start()
        {
            // Получаем компоненты кнопки
            save = JsonUtility.FromJson<SaveGame>(PlayerPrefs.GetString("save"));
            button = GetComponent<Button>();
            text = GetComponentInChildren<Text>();

            text.text = (id + 1).ToString();
            // В зависимости от открытия уровня деактивируем или привязываем действие
            if (save.levels[id] == -1)
            {
                button.interactable = false;

            }
            else
            {
                button.onClick.AddListener(StartGame);
                for (int i = 0; i < save.levels[id]; i++)
                {
                    stars[i].SetActive(true);
                }
            }

            
        }

        private void StartGame()
        {
            // Сохраняем выбранный уровень
            PlayerPrefs.SetInt("currentLvl", id);
            // Отправяемся на локацию
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 + id / 6);
        }
    }
}
