using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public ParticleSystem explosion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       explosion.Stop();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            explosion.Play();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            explosion.Stop();
        }
    }
}
