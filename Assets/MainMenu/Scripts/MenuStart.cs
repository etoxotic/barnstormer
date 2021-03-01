using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartMenu
{
    public class MenuStart : MonoBehaviour
    {
        [SerializeField] private GameObject menuSettings;
        [SerializeField] private GameObject menuQuit;
        [SerializeField] private GameObject menuPlane;

        public void PlayButton()
        {
            menuPlane.SetActive(true);
            gameObject.SetActive(false);
        }

        public void SettingsButton()
        {
            menuSettings.SetActive(true);
            gameObject.SetActive(false);
        }

        public void QuitButton()
        {
            menuQuit.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}