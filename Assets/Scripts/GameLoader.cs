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
    [SerializeField] private TerrainGenerator terrain;


    private GameObject player;
    private Quest.Quest quest;

    SaveGame save;

    private void Start()
    {
        // ��������� ����������
        save = JsonUtility.FromJson<SaveGame>(PlayerPrefs.GetString("save"));
        // �������� ������
        player = players[save.selectedAircraft];
        // ������������� ������
        player = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
        terrain.SetViewer(player.transform.Find("Gears").transform);
        // ������������� �����
        quest = Instantiate(quests[PlayerPrefs.GetInt("currentLvl") % 3]).GetComponent<Quest.Quest>();
        // �������� ����� �������� ����
        inGameMenu.quest = quest;
        // ������������� �� ������� ���������� ������
        quest.OnFinish.AddListener(Finish);
    }

    private void Finish()
    {
        // �������� ������� �������
        int currentLvl = PlayerPrefs.GetInt("currentLvl");
        // ���������� ���������� �������
        if (currentLvl != save.levels.Length)
            PlayerPrefs.SetInt("currentLvl", currentLvl + 1);
        // �������� ���� ����������
        save.levels[currentLvl] = quest.Stars;
        if (currentLvl != save.levels.Length && save.levels[currentLvl + 1] == -1)
            save.levels[currentLvl + 1] = 0;
        // � ��������� ���
        PlayerPrefs.SetString("save", JsonUtility.ToJson(save));
        PlayerPrefs.Save();
        // �������� ���� ������
        winMenu.SetActive(true);
        // ������������� �����
        Time.timeScale = 0f;
    }

}
