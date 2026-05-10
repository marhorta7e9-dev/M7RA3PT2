using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mal : MonoBehaviour
{
    public GameObject _mal;
    public GameObject GameOver;
    public int vidas = 3;
    public GameObject vida1, vida2, vida3;
    public PlayerScriptableObject _playerSO;
   
    public void Start()
    {
        // si no tenim guadades dades de Lives les posem a 3 (vida inicial)
        if (!PlayerPrefs.HasKey("Lives"))
        {
             _playerSO.vida = 3;
             vidas = 3;
        }
        else
        {
            _playerSO.vida = PlayerPrefs.GetInt("Lives");
            vidas = PlayerPrefs.GetInt("Lives");
        }
        _mal.SetActive(false);
        
       if (vidas == 3)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(true);
        }
        else if (vidas == 2)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(false);
        }
        else if (vidas == 1)
        {
            vida1.SetActive(true);
            vida2.SetActive(false);
            vida3.SetActive(false);
        }
        GameOver.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mal.SetActive(true);
           Perdrevida();
           
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mal.SetActive(false);
        }
    }
    public void Perdrevida()
    {
        vidas--;
        _playerSO.vida--;
        Debug.Log("Vida de " + _playerSO.nom + " es: " + _playerSO.vida);
        if (vidas == 2)
        {
            vida3.SetActive(false);
        }
        else if (vidas == 1)
        {
            vida2.SetActive(false);
        }
       
        if (vidas <= 0)
        {
            vida1.SetActive(false);
            GameOver.SetActive(true);
        }
    }

}
