using UnityEngine;

// Это главный скрипт для квеста (мини игры)
// Для удобства построения квеста в редакторе, квест будет строиться из сфер, 
// которые этот скрипт будет заменять на кольца, повернутые в правильное положение.
// Также в данном скрипте будут содержаться события начала и конца прохождения и
// информация для пользовательского интерфейса.
public class Quest : MonoBehaviour
{
    private Transform[] points;
    void Start()
    {
        points = gameObject.GetComponentsInChildren<Transform>();
        foreach (var point in points)
        {
            print(point.gameObject.name);
        }
    }
}
