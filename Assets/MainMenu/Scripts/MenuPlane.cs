using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartMenu
{
    public class MenuPlane : MonoBehaviour
    {
        [SerializeField] private GameObject menuStart;
        [SerializeField] private GameObject menuLevel;

        public void BackButton()
        {
            menuStart.SetActive(true);
            gameObject.SetActive(false);
        }
        public void LeftButton()
        {

        }
        public void RightButton()
        {

        }
        public void SelectButton()
        {
            menuLevel.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
