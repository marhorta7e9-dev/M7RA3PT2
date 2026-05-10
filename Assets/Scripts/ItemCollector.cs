using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.Cinemachine;

public class wineCollector : MonoBehaviour
{
      private Animator _animator;
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>(); //Agafa el component animator del fill del jugador, que es on esta l'animacio de col·leccionar.
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ICollectable>(out ICollectable icoll)) // Comproba si l'objecte que ha entrat en contacte amb el jugador es un item col·leccionable
        {
            icoll.OnCollected();

            if (icoll is Item) // Si el item col·leccionable es un Item, comença el codi de col·leccionar l'Item
            {
                _animator.SetTrigger("Collected");
                _animator.SetLayerWeight(1, 1);
                Camera.main.GetComponent<CinemachineBrain>().enabled = true;
                GetComponent<PlayerController2526>().canMove = false;
            }
        }
    }
}
