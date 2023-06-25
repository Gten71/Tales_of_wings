using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public List<Transform> spawnPoints; // ������ ����� ������ ������
    public GameObject enemyPrefab; // ������ �����


    private void Start()
    {
        // �������� ��� ����� ������ �� �������� ��������
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child);
        }

        // ������� ������ �� ��������� ����� ������
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        // �������� ��������� ����� ������ �� ������
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[randomIndex];

        // ������� ����� �� ��������� ����� ������
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // �������������� �������� ��� �������� �����, ��������, ��������� ��� ���������� ��� ������ �� ������ ����������
    }
}

