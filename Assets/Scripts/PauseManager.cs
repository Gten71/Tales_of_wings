using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

//public class PauseManager : MonoBehaviour
//{
//    public GameObject pauseMenuPanel; // Ссылка на панель меню паузы

//    private bool isPaused = false;

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            isPaused = !isPaused;
//            if (isPaused)
//            {
//                PauseGame();
//            }
//            else
//            {
//                ResumeGame();
//            }
//        }
//    }

//    private void PauseGame()
//    {
//        Time.timeScale = 0f; // Остановка времени в игре
//        pauseMenuPanel.SetActive(true); // Включение панели меню паузы
//    }

//    private void ResumeGame()
//    {
//        Time.timeScale = 1f; // Возобновление времени в игре
//        pauseMenuPanel.SetActive(false); // Отключение панели меню паузы
//    }
//}
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isPaused = !pauseMenuPanel.activeSelf;
            SetPauseMenuState(isPaused);
        }
    }

    private void SetPauseMenuState(bool isPaused)
    {
        Time.timeScale = isPaused ? 0f : 1f;
        pauseMenuPanel.SetActive(isPaused);
    }
}
