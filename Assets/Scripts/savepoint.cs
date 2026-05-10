using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class savepoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }


    // Quan el jugador entra al trigger del savepoint, es guarda la seva posició
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Guardem la posició REAL del jugador (other), no del savepoint
            PlayerPrefs.SetFloat("playerPosX", other.transform.position.x);
            PlayerPrefs.SetFloat("playerPosY", other.transform.position.y);
            PlayerPrefs.SetFloat("playerPosZ", other.transform.position.z);

            // Guardem la rotació del jugador
            PlayerPrefs.SetFloat("playerRotX", other.transform.rotation.eulerAngles.x);
            PlayerPrefs.SetFloat("playerRotY", other.transform.rotation.eulerAngles.y);
            PlayerPrefs.SetFloat("playerRotZ", other.transform.rotation.eulerAngles.z);

            // Guardem les dades de forma persistent
            PlayerPrefs.Save();

            Debug.Log("Savepoint activat! Posició guardada: " + other.transform.position);
        }
    }
}
