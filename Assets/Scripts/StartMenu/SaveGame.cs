using System;
using UnityEngine;

// Ёто класс с сохранением игры
[Serializable]
public class SaveGame
{
    public int[] levels; // -1 - уровень закрыт, 0 - уровень открыт, 1 - 3 уровень пройден на определенное количество звезд
    public bool[] unlockedAircraft; // ќткрыт ли самолет
    public int selectedAircraft; // ¬ыбранный самолет

    public SaveGame()
    {
        int levelsCount = 18; //  оличество уровней
        levels = new int[levelsCount]; // —оздаем массив уровней
        levels[0] = 0; // ќткрываем первый уровень
                        // «акрывем все остальные
        for (int i = 1; i < levels.Length; i++)
        {
            levels[i] = -1;
        }

        // ќткрываем первый самолет, закрываем все остальные
        unlockedAircraft = new bool[3];
        unlockedAircraft[0] = true;
        unlockedAircraft[1] = false;
        unlockedAircraft[2] = false;

        // ¬ыбираем первый самолет
        selectedAircraft = 0;
    }
}
