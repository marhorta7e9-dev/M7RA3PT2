using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;



public class GameManager : MonoBehaviour
{
    public static GameManager gamemanager;
    public int Orbs = 0, Coins = 0, Wine = 0; // Orbs: Objectes Estatues - Coins: Monedes.
    public TextMeshProUGUI TextOrbs, TextCoin, TextWine;
    public Image[] Items;
    public GameObject _pauseMenu;
    public bool isPaused = false;
    public GameObject[] GOitems;
    public PlayerScriptableObject _playerSO;

    

    void Start()
    {
        Debug.Log("La vida de " + _playerSO.nom + " es: " + _playerSO.vida);

        _pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _pauseMenu.SetActive(!_pauseMenu.activeSelf);
        }

    }

    void Awake()
    {
        if (GameManager.gamemanager != null && GameManager.gamemanager != this) //Si ja existeix un GameManager i no és este, destruïm este.
        {
            Destroy(gamemanager);
        }
        else
        {
            //PlayerPrefs.DeleteAll(); // Elimina tots els datos guardados en PlayerPrefs. Útil para pruebas, pero ten cuidado al usarlo en producción.
            GameManager.gamemanager = this;
            DontDestroyOnLoad(gamemanager);

            // Carreguem els totals guardats (si existeixen)
            Coins = PlayerPrefs.GetInt("TotalCoins", 0);
            Orbs  = PlayerPrefs.GetInt("TotalOrbs", 0);
            Wine  = PlayerPrefs.GetInt("TotalWine", 0);

            TextWine.text = Wine.ToString();
            TextOrbs.text = Orbs.ToString();
            TextCoin.text = Coins.ToString();
        }
    }

    public void OrbCollected(int i) //Quan es recull una estatua, sumem 1 a Orbs i actualitzem el text de la UI.
    {
        Orbs += i;
        TextOrbs.text = Orbs.ToString();
        PlayerPrefs.SetInt("TotalOrbs", Orbs);
        PlayerPrefs.Save();
    }

    public void CoinCollected(int i) //Quan es recull una moneda, sumem 1 a Coins i actualitzem el text de la UI.
    {
        Coins += i;
        TextCoin.text = Coins.ToString();
        PlayerPrefs.SetInt("TotalCoins", Coins);
        PlayerPrefs.Save();
    }
    public void WineCollected(int i) //Quan es recull una ampolla de vi, sumem 1 a Wine i actualitzem el text de la UI.
    {
        Wine += i;
        TextWine.text = Wine.ToString();
        PlayerPrefs.SetInt("TotalWine", Wine);
        PlayerPrefs.Save();
    }
    public void ItemCollected(Sprite sprite, int id) //Quan es recull un item, actualitzem la imatge de l'item a la UI.
    {
        Items[id].sprite = sprite;
        GOitems[id].SetActive(true);
    }
    public void LivesCollected(int i)
    {
        _playerSO.vida += i;
    }
}
