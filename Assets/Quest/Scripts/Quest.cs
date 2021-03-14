using UnityEngine;

// Это главный скрипт для квеста (мини игры)
// Для удобства построения квеста в редакторе, квест будет строиться из сфер, 
// которые этот скрипт будет заменять на кольца, повернутые в правильное положение.
// Также в данном скрипте будут содержаться события начала и конца прохождения и
// информация для пользовательского интерфейса.
public class Quest : MonoBehaviour
{
    [SerializeField] private GameObject ringPrefab;
    [SerializeField] private Material activeMaterial;
    [SerializeField] private Material unactiveMaterial;

    private Checkpoint[] points;
    private Ring[] rings;
    private int currentRing;

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
        rings[0].OnEnter.AddListener(RingEnterHandler);
    }

    private void RingEnterHandler()
    {

    }
}
