using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orbe : MonoBehaviour, ICollectable
{
    public int value;
    public void OnCollected()
    {
        GameManager.gamemanager.OrbCollected(value);
        Debug.Log("Espasa recollida");
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
