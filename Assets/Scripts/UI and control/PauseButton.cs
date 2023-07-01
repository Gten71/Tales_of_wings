using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseMenuPanel;

    private void Start()
    {
        // Назначьте функцию PauseButtonOnClick() как обработчик нажатия кнопки
        GetComponent<Button>().onClick.AddListener(PauseButtonOnClick);
    }

    private void PauseButtonOnClick()
    {
        // Показать/скрыть меню паузы при нажатии кнопки
        bool isPaused = !pauseMenuPanel.activeSelf;
        SetPauseMenuState(isPaused);
    }

    private void SetPauseMenuState(bool isPaused)
    {
        // Установить состояние меню паузы
        Time.timeScale = isPaused ? 0f : 1f;
        pauseMenuPanel.SetActive(isPaused);
    }
}
