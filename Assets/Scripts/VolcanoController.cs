using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VolcanoController : MonoBehaviour
{
    [Header("Configuració de l'Erupció")]
    public float tempsEntreErupcions = 4f;
    public AudioClip soVolca;

    [Header("Configuració del Tremolor (Camera Shake)")]
    public float duradaTremolor = 0.5f;
    public float intensitatTremolor = 0.1f;

    private AudioSource audioSource;
    private Transform mainCameraTransform;

    void Start()
    {
        // Obtenim l'AudioSource adjunt a aquest objecte
        audioSource = GetComponent<AudioSource>();
        
        // Obtenim el Transform de la càmera principal
        if (Camera.main != null)
        {
            mainCameraTransform = Camera.main.transform;
        }
        else
        {
            Debug.LogError("No s'ha trobat cap càmera amb l'etiqueta 'MainCamera'.");
        }

        // Iniciem la corrutina principal
        StartCoroutine(RutinaVolca());
    }

    private IEnumerator RutinaVolca()
    {
        // Bucle infinit perquè el volcà vagi erupcionant
        while (true)
        {
            // Esperem els 4 segons que has demanat
            yield return new WaitForSeconds(tempsEntreErupcions);

            // 1. Reproduir el so del volcà
            if (soVolca != null)
            {
                audioSource.PlayOneShot(soVolca);
            }

            // 2. Activar el Camera Shake
            if (mainCameraTransform != null)
            {
                StartCoroutine(ShakeCamera(duradaTremolor, intensitatTremolor));
            }
        }
    }

    private IEnumerator ShakeCamera(float durada, float intensitat)
    {
        // Guardem la posició original de la càmera abans de moure-la
        Vector3 posicioOriginal = mainCameraTransform.localPosition;
        float tempsPassat = 0.0f;

        while (tempsPassat < durada)
        {
            // Generem una posició aleatòria basada en la intensitat
            float x = Random.Range(-1f, 1f) * intensitat;
            float y = Random.Range(-1f, 1f) * intensitat;

            // Apliquem el desplaçament a la càmera
            mainCameraTransform.localPosition = new Vector3(posicioOriginal.x + x, posicioOriginal.y + y, posicioOriginal.z);

            tempsPassat += Time.deltaTime;

            // Esperem al següent frame
            yield return null;
        }

        // Retornem la càmera exactament a la seva posició original quan acaba el tremolor
        mainCameraTransform.localPosition = posicioOriginal;
    }
}