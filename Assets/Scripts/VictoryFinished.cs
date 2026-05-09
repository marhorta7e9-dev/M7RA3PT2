using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;

public class VictoryFinished : StateMachineBehaviour
{

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.parent.gameObject.GetComponent<PlayerController2526>().canMove = true; //Quan acaba l'animacio de col·leccionar, permet al jugador moure's de nou.
        Camera.main.GetComponent<CinemachineBrain>().enabled = false; //Desactiva la camera de Cinemachine per tornar a la camera normal del joc.
    }
}
