using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField] private GameObject levelMenu;
        [SerializeField] private GameObject aircraftMenu;
        [Space]
        [SerializeField] private Button aircraftButton;
        [SerializeField] private Button levelButton;
        [SerializeField] private Button quitButton;
        [Space]
        [SerializeField] private CameraMotion cameraMotion;

        private void Start()
        {
            aircraftButton.onClick.AddListener(Aircraft);
            levelButton.onClick.AddListener(Level);
            quitButton.onClick.AddListener(Quit);

            // Проверяем есть ли сохранение. Если нет, создаем новое
            if (!PlayerPrefs.HasKey("save"))
            {
                SaveGame save = new SaveGame();
                PlayerPrefs.SetString("save", JsonUtility.ToJson(save));
            }
        }

        private void Aircraft()
        {
            // Переключаем меню
            aircraftMenu.SetActive(true);
            gameObject.SetActive(false);
            // Управление камерой
            cameraMotion.MenuPossition = 1;
        }

        private void Level()
        {
            // Переключаем меню
            levelMenu.SetActive(true);
            gameObject.SetActive(false);
        }
        private void Quit()
        {
            // Выходим
            Application.Quit();
        }
    }
}