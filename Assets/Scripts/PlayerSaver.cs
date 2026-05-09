using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSaver : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        //PlayerPrefs.DeleteAll(); // Elimina tots els datos guardats en PlayerPrefs. Útil per a proves.

        // Només carreguem la posició si hi ha un savepoint activat
        if (PlayerPrefs.HasKey("playerPosX") && PlayerPrefs.HasKey("playerPosY") && PlayerPrefs.HasKey("playerPosZ"))
        {
            // Usem coroutine per aplicar-la UN FRAME DESPRÉS
            // perquè el CharacterController acaba d'inicialitzar-se i sobreescriuria la posició
            StartCoroutine(AplicarPosicioSaved());
        }
        else
        {
            Debug.Log("No hi ha savepoint guardat. El jugador comença a la posició inicial.");
        }
    }

    // Esperem un frame perquè el CharacterController no sobreescrigui la posició
    private IEnumerator AplicarPosicioSaved()
    {
        yield return null; // espera 1 frame

        float posX = PlayerPrefs.GetFloat("playerPosX");
        float posY = PlayerPrefs.GetFloat("playerPosY");
        float posZ = PlayerPrefs.GetFloat("playerPosZ");

        float rotX = PlayerPrefs.GetFloat("playerRotX");
        float rotY = PlayerPrefs.GetFloat("playerRotY");
        float rotZ = PlayerPrefs.GetFloat("playerRotZ");

        // Si el jugador té CharacterController, cal desactivar-lo temporalment per moure'l
        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        player.transform.position = new Vector3(posX, posY, posZ);
        player.transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);

        if (cc != null) cc.enabled = true;

        Debug.Log("Posició carregada: " + player.transform.position + " | Rotació: " + player.transform.rotation.eulerAngles);
    }
}
