using UnityEngine;

namespace Player.Controls
{
    public class PCControls : MonoBehaviour, IControls
    {
        public float roll { get; private set; }
        public float yaw { get; private set; }
        public float pitch { get; private set; }
        public float thrust { get; private set; }
        public bool gearsOut { get; private set; }
        public bool brake { get; private set; }

        private void Start()
        {
            thrust = 0;
            gearsOut = true;
        }
        private void Update()
        {
            // Крен
            roll = Input.GetAxis("Horizontal");

            // Тангаж
            pitch = Input.GetAxis("Vertical");

            // Рыскание
            yaw = 0f;
            if (Input.GetKey(KeyCode.Q))
                yaw++;
            if (Input.GetKey(KeyCode.E))
                yaw--;

            // Газ
            if (Input.GetKey(KeyCode.LeftShift))
                thrust = Mathf.Clamp(thrust + Time.deltaTime, 0, 1);
            if (Input.GetKey(KeyCode.LeftControl))
                thrust = Mathf.Clamp(thrust - Time.deltaTime, 0, 1);

            // Шасси
            if (Input.GetKeyDown(KeyCode.G))
                gearsOut = !gearsOut;

            // Тормоз
            brake = (Input.GetKey(KeyCode.LeftControl) && thrust == 0);
                
        }
    }
}
