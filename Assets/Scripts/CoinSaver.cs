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
            gameObject.SetActive(false); // Amaguem la moneda, ja estava recollida
        }
        if (PlayerPrefs.HasKey("Orbs" + ID) && PlayerPrefs.GetInt("Orbs" + ID) == 1)
        {
            gameObject.SetActive(false);
        }
        if (PlayerPrefs.HasKey("wine" + ID) && PlayerPrefs.GetInt("wine" + ID) == 1)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Només guardem si és el jugador qui recull la moneda
        if (!other.CompareTag("Player")) return;

        // Marquem AQUESTA moneda com a recollida (1 = recollida)
        if (GetComponent<Coin>() != null)
            PlayerPrefs.SetInt("Coins" + ID, 1);
        if (GetComponent<Orbe>() != null)
            PlayerPrefs.SetInt("Orbs" + ID, 1);
        // Afegir aquí altres tipus si cal (wine, etc.)

        PlayerPrefs.Save();
    }
}

