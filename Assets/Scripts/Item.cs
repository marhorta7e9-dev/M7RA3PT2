using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Item : MonoBehaviour, ICollectable
{
    public int id; //Identificador de l'item, que ens permet saber quin item és i guardar si ha estat recollit o no.
    public Sprite Sprite;//Imatge de l'item, que es mostrarà a la UI quan el jugador el reculli.
 
    void Start()
    {
        //PlayerPrefs és una classe que ens permet guardar dades de manera persistent, és a dir, que no es perden quan tanquem el joc. En aquest cas, estem guardant un enter amb la clau "Item" + id, on id és l'identificador de l'item. Si el valor guardat és 1, vol dir que l'item ja ha estat recollit i no hauria d'aparèixer al joc.
        if (PlayerPrefs.GetInt("Item" + id, 0) == 1)
        {
            GameManager.gamemanager.ItemCollected(Sprite, id); //El posem a la UI amb la imatge de l'item recollit.
            Destroy(gameObject);
        }
    }
    public void OnCollected()
    {
        GameManager.gamemanager.ItemCollected(Sprite, id);
        PlayerPrefs.SetInt("Item" + id, 1); //Guardem que aquest item ha estat recollit, així no apareixerà més al joc.
        Debug.Log("Item recollit");
        Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider other)//Quan el jugador entra en contacte amb l'item, comença el codi de colleccionar.
    {
        if (other.CompareTag("Player"))
        {
            OnCollected();
            Debug.Log("Player ha recollit l'item");
           
        }
    }
}
