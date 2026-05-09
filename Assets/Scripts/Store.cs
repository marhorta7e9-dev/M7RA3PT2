using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    public ScriptableObjectScript Item1;
    public Image Image1;
    public TextMeshProUGUI TextItem1;
    public Button Buy1;

    public void Start()
    {
    }
    void OnEnable()
    {
        Debug.Log("Store enabled");
        Image1.sprite = Item1.image;

        checkIfCanBuy(Item1, TextItem1, Buy1);
    }

    public void BuyItem1()
    {
        GameManager.gamemanager.WineCollected(1);//Sumem 1 a Wine quan es compra l'item.
        GameManager.gamemanager.CoinCollected(-Item1.price);
        checkIfCanBuy(Item1, TextItem1, Buy1);
    }


    private void checkIfCanBuy(ScriptableObjectScript item, TextMeshProUGUI insuCoins, Button buyButton)
    {
        if (GameManager.gamemanager.Coins >= item.price)
        {
            insuCoins.text = "" + item.price;
            insuCoins.color = Color.yellow;
            buyButton.interactable = true;
        }
        else
        {
            insuCoins.text = "insuficiente coins: " + item.price;
            insuCoins.color = Color.red;
            buyButton.interactable = false;
        }
    }
    /*public void ExitStore().       NO FA FALTA
    {
        //Time.timeScale = 1f;

        //UI.SetActive(false);
    }*/
}

