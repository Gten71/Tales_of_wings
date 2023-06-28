using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseMenuPanel;

    private void Start()
    {
        // ��������� ������� PauseButtonOnClick() ��� ���������� ������� ������
        GetComponent<Button>().onClick.AddListener(PauseButtonOnClick);
    }

    private void PauseButtonOnClick()
    {
        // ��������/������ ���� ����� ��� ������� ������
        bool isPaused = !pauseMenuPanel.activeSelf;
        SetPauseMenuState(isPaused);
    }

    private void SetPauseMenuState(bool isPaused)
    {
        // ���������� ��������� ���� �����
        Time.timeScale = isPaused ? 0f : 1f;
        pauseMenuPanel.SetActive(isPaused);
    }
}
