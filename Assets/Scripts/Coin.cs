using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Coin : MonoBehaviour, ICollectable
{
    public int value;

    public void OnCollected()
    {
        GameManager.gamemanager.CoinCollected(value);
        Debug.Log("Moneda recollida");
        Destroy(gameObject);
    }
     /* public void OnTriggerEnter(Collider other)//Quan el jugador entra en contacte amb l'item, comença el codi de colleccionar.
    {
        if (other.CompareTag("Player"))
        {
            OnCollected();
        }
    }*/
}
