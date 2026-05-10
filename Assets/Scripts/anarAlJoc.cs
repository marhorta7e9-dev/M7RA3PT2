using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class anarAlJoc : MonoBehaviour
{
    public GameObject credits;
    public GameObject boto1, boto2;

    public void Start()
    {
        credits.SetActive(false);
            }

    public void Iniciar(string M7PT2)
    {
        Time.timeScale = 1f; // Reiniciem per si el joc estava pausat
        SceneManager.LoadScene(M7PT2);

    }
    public void Creditos() { 
    credits.SetActive(true);
    }
    public void Menu()
    {
        credits.SetActive(false);
    }
    public void TornarAlMenu() // Funció sense paràmetres per tornar al menú principal
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Inicio");
        boto1.GetComponent<Animator>().StartPlayback();// Inicia l'animació del boto1
        boto2.GetComponent<Animator>().StartPlayback();
    }
   
    public void Exit()
    {
        Application.Quit();
    }

}
