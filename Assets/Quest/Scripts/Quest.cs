using UnityEngine;
using UnityEngine.Events;

// Это главный скрипт для квеста (мини игры)
// Для удобства построения квеста в редакторе, квест будет строиться из сфер, 
// которые этот скрипт будет заменять на кольца, повернутые в правильное положение.
// Также в данном скрипте будут содержаться события начала и конца прохождения и
// информация для пользовательского интерфейса.
public class Quest : MonoBehaviour
{
    [SerializeField] private GameObject ringPrefab;

    private Checkpoint[] points;
    private Ring[] rings;
    private int currentRing = 0;

    private UnityEvent OnStart = new UnityEvent();
    private UnityEvent OnFinish = new UnityEvent();

    private void Start()
    {
        // Получаем все чекпоинты
        points = gameObject.GetComponentsInChildren<Checkpoint>();
        // Создаем массив для колец
        rings = new Ring[points.Length];
        // Ставим кольца
        for (int i = 0; i < points.Length; i++) 
        {
            // Полкчаем i-тый чекпоинт
            Checkpoint point = points[i]; 
            // Устанавливаем кольцо на место чекпоинта
            GameObject ring = Instantiate(ringPrefab, point.transform.position, point.transform.rotation, transform);
            // Меняем название кольца
            ring.name = "Ring " + point.id;
            // Добавляем кольцо в массив колец
            rings[i] = ring.GetComponent<Ring>();
            //Удаляем чекпоинт
            Destroy(point.gameObject);
        }
        // Подпписываемся на события входа в первое кольцо
        rings[0].OnEnter.AddListener(RingEnterHandler);

        // Терперь отобразим первые две точки квеста
        rings[0].Activate(false);
        for (int i = 2; i < rings.Length; i++)
        {
            rings[i].gameObject.SetActive(false);
        }
    }

    private void RingEnterHandler()
    {
        // Отписываемся от события входа в текущее кольцо
        rings[currentRing].OnEnter.RemoveListener(RingEnterHandler);
        rings[currentRing].gameObject.SetActive(false);

        //      Теперь обрабатываем особые случаи
        // Если мы входим в первое кольцо
        if (currentRing == 0)
        {
            // Вызываем событие начала мини игры
            OnStart.Invoke();
            print("Start");
        }
        // Если мы вошли в последнее кольцо
        if (currentRing == rings.Length - 1)
        {
            // Вызываем событие окнчания мини игры
            OnFinish.Invoke();
            print("Finish");
        }


        //    Теперь разберемся с тем, как меняется квест
        // Если мы попали в любое кольцо кроме последнего и предпоследнего
        if(currentRing < rings.Length - 2)
        {
            // Включаем кольцо через одно
            rings[currentRing + 2].gameObject.SetActive(true);
            // Активируем следующее
            rings[currentRing + 1].Activate(false);
            // Подписываемся на событи входа в следующее кольцо
            rings[currentRing + 1].OnEnter.AddListener(RingEnterHandler);
        }
        // Если попали в предпоследнее кольцо
        if(currentRing == rings.Length - 2)
        {
            // Активируем следующее c финишным цветом
            rings[currentRing + 1].Activate(true);
            // Подписываемся на событи входа в следующее кольцо
            rings[currentRing + 1].OnEnter.AddListener(RingEnterHandler);
        }
        currentRing = currentRing + 1;
    }
}
