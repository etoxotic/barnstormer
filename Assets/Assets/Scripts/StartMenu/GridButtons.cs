using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class GridButtons : MonoBehaviour
    {
        [SerializeField] private GameObject buttonPrefab;
        void Start()
        {
            for (int i = 0; i < 6; i++)
            {
                GameObject button = Instantiate(buttonPrefab, transform);
                button.GetComponent<LevelButton>().Init(i);
            }
        }
    }
}
