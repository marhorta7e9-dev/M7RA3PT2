using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.Cinemachine;

public class OrbCollector : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>(); //Agafa el component animator del fill del jugador, que es on esta l'animacio de col·leccionar.
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ICollectable>(out ICollectable icoll))//comproba si l'objecte que ha entrat en contacte amb el jugador es un item colleccionable, si es així, comença el codi de colleccionar.
        {
            icoll.OnCollected();

        }
        if (icoll is Orbe) //Si el item colleccionable es un Orbe, comença el codi de col·leccionar l'Orbe.
        {
           /* _animator.SetTrigger("Collected");
            _animator.SetLayerWeight(1, 1);
            Camera.main.GetComponent<CinemachineBrain>().enabled = true;
            GetComponent<PlayerController2526>().canMove = false;*/
        }
    }
}
