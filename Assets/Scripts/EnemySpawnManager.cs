using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public List<Transform> spawnPoints; // Список точек спавна врагов
    public GameObject enemyPrefab; // Префаб врага


    private void Start()
    {
        // Получаем все точки спавна из дочерних объектов
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child);
        }

        // Создаем врагов на случайной точке спавна
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        // Выбираем случайную точку спавна из списка
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Создаем врага на выбранной точке спавна
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Дополнительные действия при создании врага, например, настройка его параметров или ссылок на другие компоненты
    }
}

