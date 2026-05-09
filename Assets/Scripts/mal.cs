using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mal : MonoBehaviour
{
    public GameObject _mal;
    public GameObject GameOver;
    public int vidas = 3;
   
    public void Start()
    {
        _mal.SetActive(false);
        GameOver.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mal.SetActive(true);
           // Perdrevida();
           
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mal.SetActive(false);
        }
    }
    public void Perdrevida()
    {
        vidas--;
        if (vidas <= 0)
        {
            GameOver.SetActive(true);
        }
    }

}
