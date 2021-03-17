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
            // �������� ���������� ����
            save = JsonUtility.FromJson<SaveGame>(PlayerPrefs.GetString("save"));
            // ������� �� ���� ����� ��������
            currentAircraft = save.selectedAircraft;
            // ������������� �� ������� ������
            leftButton.onClick.AddListener(Left);
            rightButton.onClick.AddListener(Right);
            selectButton.onClick.AddListener(Select);

            SetLocked();
        }

        private void Left()
        {
            // ���� ������ �� ������� ����� ������� ��������� �����
            if (currentAircraft > 0)
            {
                currentAircraft -= 1;
                cameraMotion.CurrentAircraft = currentAircraft;
            }
            SetLocked();
        }
        private void Right()
        {
            // ���� ������ �� ������� ������ ������� ��������� ������
            if (currentAircraft < 2)
            {
                currentAircraft += 1;
                cameraMotion.CurrentAircraft = currentAircraft;
            }
            SetLocked();
        }
        private void Select()
        {
            // ���� ������� ������
            if (save.unlockedAircraft[currentAircraft])
            {
                // �������� ���
                save.selectedAircraft = currentAircraft;
                // � �����������
                PlayerPrefs.SetString("save", JsonUtility.ToJson(save));
                PlayerPrefs.Save();
                startMenu.SetActive(true);
                gameObject.SetActive(false);
            }
            // ���������� �������
            cameraMotion.MenuPossition = 0;
        }

        // ��� ������� ��������� �������������� ������
        private void SetLocked()
        {
            leftButton.interactable = currentAircraft > 0;
            rightButton.interactable = currentAircraft < 2;
            selectButton.interactable = save.unlockedAircraft[currentAircraft];
        }
    }
}