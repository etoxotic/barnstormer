using UnityEngine.UI;
using UnityEngine;

namespace Menu
{
    public class ArircraftMenu : MonoBehaviour
    {
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;
        [SerializeField] private Button selectButton;
        [Space]
        [SerializeField] private GameObject startMenu;
        [Space]
        [SerializeField] private CameraMotion cameraMotion;

        private int currentAircraft;
        private SaveGame save;

        private void Awake()
        {
            // Получаем сохранение игры
            save = JsonUtility.FromJson<SaveGame>(PlayerPrefs.GetString("save"));
            // Достаем из него номер самолета
            currentAircraft = save.selectedAircraft;
            // Подписываемся на события кнопки
            leftButton.onClick.AddListener(Left);
            rightButton.onClick.AddListener(Right);
            selectButton.onClick.AddListener(Select);

            SetLocked();
        }

        private void Left()
        {
            // Если выбран не крайний левый самолет свигаемся влево
            if (currentAircraft > 0)
            {
                currentAircraft -= 1;
                cameraMotion.CurrentAircraft = currentAircraft;
            }
            SetLocked();
        }
        private void Right()
        {
            // Если выбран не крайний правый самолет свигаемся вправо
            if (currentAircraft < 2)
            {
                currentAircraft += 1;
                cameraMotion.CurrentAircraft = currentAircraft;
            }
            SetLocked();
        }
        private void Select()
        {
            // Если самолет открыт
            if (save.unlockedAircraft[currentAircraft])
            {
                // Выбираем его
                save.selectedAircraft = currentAircraft;
                // И сохраняемся
                PlayerPrefs.SetString("save", JsonUtility.ToJson(save));
                PlayerPrefs.Save();
                startMenu.SetActive(true);
                gameObject.SetActive(false);
            }
            // Управление камерой
            cameraMotion.MenuPossition = 0;
        }

        // Эта функция блокирует неиспользуемые кнопки
        private void SetLocked()
        {
            leftButton.interactable = currentAircraft > 0;
            rightButton.interactable = currentAircraft < 2;
            selectButton.interactable = save.unlockedAircraft[currentAircraft];
        }
    }
}