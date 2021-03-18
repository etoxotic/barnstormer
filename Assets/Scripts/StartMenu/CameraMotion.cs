using UnityEngine.UI;
using UnityEngine;

namespace Menu
{
    // Этот скрипт управляеи премещением камеры в зависимости от положения в меню
    public class CameraMotion : MonoBehaviour
    {
        public int CurrentAircraft { private get; set; } = 0;
        public int MenuPossition { private get; set; } = 0;

        [SerializeField] private Vector3 offset;
        [SerializeField] private Vector3 aircraftDistance;
        [SerializeField] private Vector3 menuDistance;
        [Space]
        [SerializeField] private float speed;

        private Vector3 currentPosition;

        private void Start()
        {
            currentPosition = offset;
        }
        private void Update()
        {
            Vector3 newPosition = offset;
            newPosition += CurrentAircraft * aircraftDistance;
            newPosition += MenuPossition * menuDistance;

            currentPosition = Vector3.Lerp(currentPosition, newPosition, speed);
            transform.position = currentPosition;
        }
    }
}