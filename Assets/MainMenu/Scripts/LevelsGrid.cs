using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartMenu
{
    public class LevelsGrid : MonoBehaviour
    {
        [SerializeField] private int lvlsCount;
        [SerializeField] private GameObject lvlButton;
        private List<GameObject> buttons;
        public void Start()
        {
            buttons = new List<GameObject>();
            DrawMenu(0);
        }
        
        public void DrawMenu(int page)
        {
            DestroyMenu();
            for (int i = page * lvlsCount; i < (page + 1) * lvlsCount; i++)
            {
                GameObject button = Instantiate(lvlButton, transform);
                button.GetComponent<LevelDisplay>().Init(i + 1);
                buttons.Add(button);
            }
        }
        
        private void DestroyMenu()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                Destroy(buttons[i]);
            }
            buttons.Clear();
        }
    }
}