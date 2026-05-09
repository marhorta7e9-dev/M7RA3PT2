using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class Seller : MonoBehaviour
{
    public CinemachineVirtualCamera VCamDisable;
    public CinemachineVirtualCamera VCamEnable;
    public GameObject UI;
    public PlayerController2526 _playerMover;
    private bool _canBuy = true;
    private float time = 1f;

    void Start()
    {
    
        UI.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_canBuy)
        {
            VCamDisable.gameObject.SetActive(false);
            VCamEnable.gameObject.SetActive(true);


            Camera.main.GetComponent<CinemachineBrain>().enabled = true;
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));

            _playerMover = other.GetComponent<PlayerController2526>();
            Time.timeScale = 0f;
            _playerMover.canMove = false;
            UI.SetActive(true);
            _canBuy = false;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(WaitForABit());
    }

    public void ExitStore()
    {
        _playerMover.canMove = true;
        VCamDisable.gameObject.SetActive(true);
        Time.timeScale = 1f;
        VCamEnable.gameObject.SetActive(false);
        //Camera.main.GetComponent<CinemachineBrain>().enabled = false; //
        //Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Player")); // Mostra elementos da camada "Player" novamente
        UI.SetActive(false);
    }

    private IEnumerator WaitForABit()
    {
        yield return new WaitForSeconds(time);
        _canBuy = true;
        Time.timeScale = 1f;

    }

}
