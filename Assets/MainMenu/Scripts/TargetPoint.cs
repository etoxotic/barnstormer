using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartMenu
{
    public class TargetPoint : MonoBehaviour
    {
        [SerializeField] private Transform[] hangars;
        [SerializeField] private Transform startPosition;
        private int currentHangar;
        public void PlayButton()
        {
            transform.position = hangars[0].transform.position;
        }

        public void BackButton()
        {
            transform.position = startPosition.position;
            currentHangar = 0;
        }

        public void HangarLeft()
        {
            if (currentHangar > 0)
                currentHangar--;

            ChangeHangar();
        }

        public void HangarRight()
        {
            if (currentHangar < hangars.Length - 1)
                currentHangar++;

            ChangeHangar();
        }

        private void ChangeHangar()
        {
            transform.position = hangars[currentHangar].position;
        }
    }
}