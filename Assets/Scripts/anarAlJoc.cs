using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class anarAlJoc : MonoBehaviour
{
    public GameObject credits;

    public void Start()
    {
        credits.SetActive(false);
            }

    public void Iniciar(string M7PT2)
    {
        SceneManager.LoadScene(M7PT2);

    }
    public void Creditos() { 
    credits.SetActive(true);
    }
    public void Menu()
    {
        credits.SetActive(false);
    }
    public void Restart(string Inicio) {
        SceneManager.LoadScene(Inicio);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
