using UnityEngine;

public class provamusica : MonoBehaviour
{
    public GameObject musica;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musica.SetActive(false);
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            musica.SetActive(true);

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            musica.SetActive(false);

        }
    }
}
