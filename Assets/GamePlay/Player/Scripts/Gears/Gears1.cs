using UnityEngine;

namespace Player.Gears
{
    public class Gears1 : MonoBehaviour, IGears
    {
        [SerializeField] private GameObject[] gears;
        private WheelCollider[] wheels;
        public bool gearsOut { private get; set; }
        public bool brakes { private get; set; }
        public bool thrust { private get; set; }
        public float turn { private get; set; }

        private float minAngle = 0f, maxAngle = 60f, qurAngle = 60f;

        private void Start()
        {
            wheels = new WheelCollider[3];
            for (int i = 0; i < 3; i++)
            {
                wheels[i] = gears[i].GetComponent<WheelCollider>();
            }
        }

        private void FixedUpdate()
        {
            // Выдвижение и уборка шасси
            if (gearsOut && qurAngle < maxAngle)
            {
                qurAngle += 1;
                gears[0].transform.localRotation = Quaternion.AngleAxis(qurAngle, new Vector3(0f, 0f, 1f));
                gears[1].transform.localRotation = Quaternion.AngleAxis(-qurAngle, new Vector3(0f, 0f, 1f));
            }
            else if (!gearsOut && qurAngle > minAngle)
            {
                qurAngle -= 1;
                gears[0].transform.localRotation = Quaternion.AngleAxis(qurAngle, new Vector3(0f, 0f, 1f));
                gears[1].transform.localRotation = Quaternion.AngleAxis(-qurAngle, new Vector3(0f, 0f, 1f));
            }

            // Тормоз
            if (brakes)
                for (int i = 0; i < 3; i++)
                    wheels[i].brakeTorque = 500;
            else
                for (int i = 0; i < 3; i++)
                    wheels[i].brakeTorque = 0;

            // Поворот
            wheels[2].steerAngle = 45 * turn;

            // Ускорение
            if (brakes)
                for (int i = 0; i < 3; i++)
                    wheels[i].motorTorque = 10;
            else
                for(int i = 0; i < 3; i++)
                    wheels[i].motorTorque = 0;

        }
    }
}