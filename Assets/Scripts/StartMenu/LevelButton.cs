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
            // ��������� �������, �� ������� �������� ������
            this.id = id;
        }

        private void Start()
        {
            // �������� ���������� ������
            save = JsonUtility.FromJson<SaveGame>(PlayerPrefs.GetString("save"));
            button = GetComponent<Button>();
            text = GetComponentInChildren<Text>();

            text.text = (id + 1).ToString();
            // � ����������� �� �������� ������ ������������ ��� ����������� ��������
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
            // ��������� ��������� �������
            PlayerPrefs.SetInt("currentLvl", id);
            // ����������� �� �������
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 + id / 6);
        }
    }
}
