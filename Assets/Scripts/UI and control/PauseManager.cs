using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

//public class PauseManager : MonoBehaviour
//{
//    public GameObject pauseMenuPanel; // ������ �� ������ ���� �����

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
//        Time.timeScale = 0f; // ��������� ������� � ����
//        pauseMenuPanel.SetActive(true); // ��������� ������ ���� �����
//    }

//    private void ResumeGame()
//    {
//        Time.timeScale = 1f; // ������������� ������� � ����
//        pauseMenuPanel.SetActive(false); // ���������� ������ ���� �����
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
