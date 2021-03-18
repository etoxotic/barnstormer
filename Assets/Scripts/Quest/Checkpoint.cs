using UnityEngine;

namespace Quest
{
    // Данный скрипт будет использоваться для более удобного создания новых чекпоинтов.
    // Потратить несколько часов на автоматизацию пятиминутной задачи - бесценно!  :)
    public class Checkpoint : MonoBehaviour
    {
        public int id;
        public void CreateNextCheckpoint()
        {
            // Создаем новый чекпоинт
            GameObject nextCheckpoint = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            // Даем ему новый id
            nextCheckpoint.GetComponent<Checkpoint>().id = id + 1;
            // Даем ему правильное имя
            nextCheckpoint.name = "Checkpoint " + (id + 1);
        }
    }
}