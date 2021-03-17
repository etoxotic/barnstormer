using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] quests;
    [SerializeField] private GameObject[] players;
    [SerializeField] private Transform spawnPoint;
    [Space]
    [SerializeField] private InGame inGameMenu;
    [SerializeField] private GameObject winMenu;

    private GameObject player;
    private Quest.Quest quest;

    SaveGame save;
    private void Start()
    {
        // Загружаем сохранение
        save = JsonUtility.FromJson<SaveGame>(PlayerPrefs.GetString("save"));
        // Выбираем игрока
        player = players[save.selectedAircraft];
        // Устанавливаем игрока
        Instantiate(player, spawnPoint.position, spawnPoint.rotation);
        // Устанавливаем квест
        quest = Instantiate(quests[PlayerPrefs.GetInt("currentLvl") % 6]).GetComponent<Quest.Quest>();
        // Передаем квест игровому меню
        inGameMenu.quest = quest;
        // Подписываемся на событие завершения уровня
        quest.OnFinish.AddListener(Finish);
    }
    private void Finish()
    {
        // Получаем текущий уровень
        int currentLvl = PlayerPrefs.GetInt("currentLvl");
        // Запаминаем пройденный уровень
        if (currentLvl != save.levels.Length)
            PlayerPrefs.SetInt("currentLvl", currentLvl + 1);
        // Изменяем файл сохранения
        save.levels[currentLvl] = quest.Stars;
        if (currentLvl != save.levels.Length)
            save.levels[currentLvl + 1] = 0;
        // И сохраняем его
        PlayerPrefs.SetString("save", JsonUtility.ToJson(save));
        PlayerPrefs.Save();
        // Вызываем меню победы
        winMenu.SetActive(true);
        // Останавливаем время
        Time.timeScale = 0f;
    }
    
}
