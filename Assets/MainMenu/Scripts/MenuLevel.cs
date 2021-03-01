using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartMenu
{
    public class MenuLevel : MonoBehaviour
    {
        [SerializeField] private GameObject menuSelect;
        public void BackButton()
        {
            menuSelect.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
