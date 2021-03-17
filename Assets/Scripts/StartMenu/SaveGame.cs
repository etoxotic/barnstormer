using System;
using UnityEngine;

// ��� ����� � ����������� ����
[Serializable]
public class SaveGame
{
    public int[] levels; // -1 - ������� ������, 0 - ������� ������, 1 - 3 ������� ������� �� ������������ ���������� �����
    public bool[] unlockedAircraft; // ������ �� �������
    public int selectedAircraft; // ��������� �������

    public SaveGame()
    {
        int levelsCount = 18; // ���������� �������
        levels = new int[levelsCount]; // ������� ������ �������
        levels[0] = 0; // ��������� ������ �������
                        // �������� ��� ���������
        for (int i = 1; i < levels.Length; i++)
        {
            levels[i] = -1;
        }

        // ��������� ������ �������, ��������� ��� ���������
        unlockedAircraft = new bool[3];
        unlockedAircraft[0] = true;
        unlockedAircraft[1] = false;
        unlockedAircraft[2] = false;

        // �������� ������ �������
        selectedAircraft = 0;
    }
}
