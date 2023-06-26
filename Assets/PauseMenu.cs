using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    private void Start()
    {
        Time.timeScale = 0;

    }
    public void ResumeGame()
    {
        Time.timeScale = 1f; // ������������� ������� � ����
        pauseMenuPanel.SetActive(false); // ���������� ������ ���� �����
    }

    public void ExitGame()
    {
        Application.Quit(); 
    }
}

