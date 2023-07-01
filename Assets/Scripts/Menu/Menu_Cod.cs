using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Cod : MonoBehaviour
{
    void Start()
    {
    }
    void Update()
    { 
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Load()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
}
