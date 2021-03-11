using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private Controls controls;
    [SerializeField] private float enginePower; // Мощность двигателя
    [SerializeField] private float rollPower; // Мощность крена
    [SerializeField] private float pitchPower; // Мощность тангажа
    [SerializeField] private float yawPower; // Мощность рыскания
    [SerializeField] private float tailPower; // Мощность хвостового оперения
    [SerializeField] private float liftPower; // Мощность работы крыльев
    [SerializeField] private float dragPower; // Мощность силы трения

    private void Awake()
    {
        controls = GetComponent<Controls>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Получение данных с Controls
        float pull = controls.Pull;
        float pitch = controls.Pitch;
        float roll = controls.Roll;
        float yaw = controls.Yaw;

        //Вычисление параметров, которые будут часто использоваться при расчетах
        // квадрат проекции скорости на вертикальную плоскость самолета
        float sqrSpeed = Mathf.Pow(Vector3.ProjectOnPlane(rb.velocity, transform.right).magnitude, 2);
        // Задержка времени (вдруг потом поменяем)
        float t = Time.fixedDeltaTime;
        // Испоьзуемый тип силы
        ForceMode f = ForceMode.Acceleration;

        // Приложение сил и моментов вращения
        // Ускорение двигателем (просто сила вдоль направления самолета)
        rb.AddForce(transform.forward * pull * enginePower * t, f);
        // Подъемная сила (сила, направленная вверх, зависит от скорости и угла атаки)
        rb.AddForce(transform.up * LiftCoefficient() * sqrSpeed * t, f);
        // Сила сопративления воздуха (сила, направленная против вектора скорости, зависит от угла атаки и скорости)
        rb.AddForce(-rb.velocity.normalized * DragCoefficient() * sqrSpeed * t, f);
        // Крен (момент вращения вдоль направления самолета, зависящий от скорости ЛА)
        rb.AddTorque(-transform.forward * roll * rollPower * sqrSpeed * t, f);
        // Тангаж (момент вращения вдоль поперечной оси самолета, зависит от скорости)
        rb.AddTorque(transform.right * pitch * pitchPower * sqrSpeed * t, f);
        // Рыскание (момент вращения вдоль вертикальной оси самолета, зависит от скорости)
        rb.AddTorque(-transform.up * yaw * yawPower * sqrSpeed * t, f);
        // Работа оперения (момент вращения, перепендикулярный продольной оси самолета и его скорости)
        rb.AddTorque((Vector3.Cross(transform.forward, rb.velocity)).normalized * Mathf.Pow(rb.velocity.magnitude, 2) * tailPower * t);
    }
    private float LiftCoefficient() // Функция для получения коэффициента подъемной силы, который зависит от угла атаки самолета
    {
        // Получение угла атаки
        // Для начала проекцию вектора скорости на вертикальную плоскость самолета
        // в данном упращенном варианте мы не учитываем изменение подъемной силы при скольжении
        Vector3 velToPlane = Vector3.ProjectOnPlane(rb.velocity, transform.right);

        // Затем получим угол атаки, это угол между направлением скорости и направлением носа самолета
        // поскольку знак угла имеет значение мы используем знаковую функцию получения угла
        float angle = Vector3.SignedAngle(velToPlane, transform.forward, -transform.right);
        
        // res - результирующий коэффициент
        float res = 0f;

        // При нормальном угле атаки коэффициент прямопропорционален углу атаки
        if (Mathf.Abs(angle) < 15f)
            res = angle;
        // При сваливания коэффициент резко падает
        else if (Mathf.Abs(angle) < 30f)
            res = Mathf.Sign(angle) * (30f - Mathf.Abs(angle));
        // В упрощенной модели при критических углах атаки коэффициент равен 0
        else
            res = 0f;
        // Сразу же домножим коэффициент на мощность подъемной силы
        return res * liftPower;
    }
    private float DragCoefficient()
    {
        // Получение угла атаки
        // Для начала проекцию вектора скорости на вертикальную плоскость самолета
        // в данном упращенном варианте мы не учитываем изменение подъемной силы при скольжении
        Vector3 velToPlane = Vector3.ProjectOnPlane(rb.velocity, transform.right);

        // Затем получим угол атаки, это угол между направлением скорости и направлением носа самолета
        // поскольку знак угла имеет значение мы используем знаковую функцию получения угла
        float angle = Vector3.SignedAngle(velToPlane, transform.forward, -transform.right);

        // res - результирующий коэффициент
        float res = 0f;

        // В упрощенной модели при небольших углах атаки коэффициент принимает значение 1
        if (Mathf.Abs(angle) < 15f)
            res = 1f;
        // А при сваливании возрастает до 15
        else
            res = 15f;

        // Сразу домножим на мощность силы трения
        return res * dragPower;
    }
}
