using UnityEngine;
using Player.Controls;
using Player.Drag;
using Player.Lift;
using Player.Gears;

namespace Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [Header("Параметры полета")]
        [SerializeField] float enginePower;
        [SerializeField] float liftPower;
        [SerializeField] float rollPower;
        [SerializeField] float pitchPower;
        [SerializeField] float dragPower;
        [SerializeField] float tailPower;
        [SerializeField] float yawPower;

        private IControls controls;
        private IGears gears;
        private IDrag drag;
        private ILift lift;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            gears = GetComponent<IGears>();
            controls = gameObject.AddComponent<PCControls>();
            drag = new Drag1();
            lift = new Lift1();
        }
        private void FixedUpdate()
        {
            // Настройка шасси
            gears.gearsOut = controls.gearsOut;
            gears.brakes = controls.brake;
            gears.turn = controls.yaw;
            gears.thrust = controls.thrust > 0;

            // Получения частоиспользуемых данных
            float speedSqr = Mathf.Pow(Vector3.ProjectOnPlane(rb.velocity, transform.right).magnitude, 2);
            float angle = GetAngle();
            float t = Time.fixedDeltaTime;
            ForceMode mode = ForceMode.Acceleration;

            // Сбор данных с контроллера
            float thrust = controls.thrust;
            float roll = controls.roll;
            float pitch = controls.pitch;
            float yaw = controls.yaw;


            // Ускорение двигателем
            rb.AddForce(transform.forward * thrust * enginePower * t, mode);
            // Подъемная сила
            rb.AddForce(transform.up * lift.Coefficient(angle) * liftPower * speedSqr * t, mode);
            // Сила сопративления воздуха
            rb.AddForce(-rb.velocity.normalized * drag.Coefficient(angle) * dragPower * speedSqr * t, mode);
            // Крен
            rb.AddTorque(-transform.forward * roll * rollPower * speedSqr * t, mode);
            // Тангаж
            rb.AddTorque(transform.right * pitch * pitchPower * speedSqr * t, mode);
            // Рыскание
            rb.AddTorque(-transform.up * yaw * yawPower * speedSqr * t, mode);
            // Работа оперения
            rb.AddTorque((Vector3.Cross(transform.forward, rb.velocity) - transform.right * 2.2f) * Mathf.Pow(rb.velocity.magnitude, 2) * tailPower * t);
        }
        private float GetAngle()
        {
            Vector3 velToPlane = Vector3.ProjectOnPlane(rb.velocity, transform.right);
            return Vector3.SignedAngle(velToPlane, transform.forward, -transform.right);
        }
    }
}