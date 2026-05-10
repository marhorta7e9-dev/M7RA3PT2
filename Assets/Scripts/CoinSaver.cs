using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinSaver : MonoBehaviour
{
    public int ID; // ID únic per identificar cada moneda/orbe/ampolla de vi

    void Awake()
    {
        // Si aquesta moneda ja s'ha recollit en una partida anterior, la desactivem
        if (PlayerPrefs.HasKey("Coins" + ID) && PlayerPrefs.GetInt("Coins" + ID) == 1)
        {
            //gameObject.SetActive(false); // Amaguem la moneda, ja estava recollida
        }
        if (PlayerPrefs.HasKey("Orbs" + ID) && PlayerPrefs.GetInt("Orbs" + ID) == 1)
        {
            //gameObject.SetActive(false);
        }
        if (PlayerPrefs.HasKey("Wine" + ID) && PlayerPrefs.GetInt("Wine" + ID) == 1)
        {
            //gameObject.SetActive(false);
        }
       if (PlayerPrefs.HasKey("Lives" + ID) && PlayerPrefs.GetInt("Lives" + ID) == 1)
        {
            //gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Només guardem si és el jugador qui recull la moneda
        if (!other.CompareTag("Player")) return;

        // Marquem AQUESTA moneda com a recollida (1 = recollida)
        if (GetComponent<Coin>() != null)
        {
            PlayerPrefs.SetInt("Coins" + ID, 1);
            GameManager.gamemanager.CoinCollected(1);
        }
        if (GetComponent<Orbe>() != null)
        {
            PlayerPrefs.SetInt("Orbs" + ID, 1);
            GameManager.gamemanager.OrbCollected(1);
        }
        PlayerPrefs.SetInt("Wine" + ID, 1);
        GameManager.gamemanager.WineCollected(1);
        PlayerPrefs.SetInt("Lives" + ID, 1);
        GameManager.gamemanager.LivesCollected(1);
        /*if (GetComponent<Wine>() != null)
        {
            PlayerPrefs.SetInt("Wine" + ID, 1);
            GameManager.gamemanager.WineCollected(1);
        }
 
        if (GetComponent<Lives>() != null)
        {
            PlayerPrefs.SetInt("Lives" + ID, 1);
            GameManager.gamemanager.LivesCollected(1);
        }*/
        PlayerPrefs.Save();//
    }
}

