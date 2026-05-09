using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2526 : MonoBehaviour
{

    public Vector3 externalMoveSpeed;

    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private bool Grounded;

    [SerializeField] private AudioSource walk;

    private float _maxFallSpeed = 20f;
    private float _currentFallSpeed = 0f;

    private CharacterController _controller;
    [SerializeField] private Vector3 _moveDirection = Vector3.zero;
    public float _vertical;
    public float _horizontal;

    public bool inWater;

    private float _coyoteTime = 0.4f;
    private float _jumpingTime = 0f;
    private float _timeSinceGrounded;
    private bool slope = false;

    public float input;
    private bool jumping;

    //Index punt 3
    public bool canMove = true;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        jumping = false;
        

    }

    private void FixedUpdate()
    {
        Grounded = _controller.isGrounded;

        //index 3
        if (canMove)
        {
            _vertical = _joystick.Vertical + Input.GetAxis("Vertical");
            _horizontal = _joystick.Horizontal;
            input = Mathf.Abs(_vertical) + Mathf.Abs(_horizontal);

            Vector3 cameraForward = Vector3.Scale(_cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 moveDirection = _vertical * cameraForward + _horizontal * _cameraTransform.right;
            _moveDirection.x = moveDirection.x * _moveSpeed; _moveDirection.z = moveDirection.z * _moveSpeed;

        }


        if (_controller.isGrounded)
        {
            if (_jumpingTime < 0) jumping = false;
            _currentFallSpeed = 0f;
            _timeSinceGrounded = 0f;

        }
        else
        {
            _timeSinceGrounded += Time.deltaTime;
            _moveDirection.x *= 0.7f; _moveDirection.z *= 0.7f;

            if (_moveDirection.y < -_maxFallSpeed) _moveDirection.y = -_maxFallSpeed;
            else
            {
                _currentFallSpeed += Time.deltaTime * 20f;
                _moveDirection.y -= _currentFallSpeed * Time.deltaTime;
            }
        }

        if ((_horizontal != 0 || _vertical != 0))
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(_moveDirection.x, 0, _moveDirection.z));
        }

        //Fall out with angle
        if (Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hit, 1f))
        {
            if (hit.normal.y < Mathf.Cos(50 * Mathf.Deg2Rad))
            {
                var slideDirection = new Vector3(hit.normal.x, -hit.normal.y, hit.normal.z);
                slope = true;
                _controller.Move(slideDirection * Time.fixedDeltaTime);
            }
            else
            {
                slope = false;
            }
        }
        //Index 3
        if (canMove)
        {
            _controller.Move(_moveDirection * Time.deltaTime + externalMoveSpeed * Time.deltaTime);
        }
        // if (transform.position.y < -100) Control.Death();

    }
    private void Update()
    {
        //Index 3
        if (canMove)
        {
            if (_jumpingTime > 0) _jumpingTime -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && !jumping) jump();
            foreach (Touch t in Input.touches) if (t.tapCount == 2 && !jumping) jump();

        }


        //CheckPlayerTouch();
    }

    private void LateUpdate()
    {
        animate();
    }
    private void animate()
    {

        _animator.SetBool("Grounded", !jumping && (_controller.isGrounded || _timeSinceGrounded < _coyoteTime));
        _animator.SetBool("InWater", inWater);

        if (_controller.isGrounded)
        {

            if (_jumpingTime < 0) _animator.SetBool("Jump", false);

            if (_horizontal != 0 || _vertical != 0)
            {
                _animator.speed = Mathf.Min(Mathf.Max(Mathf.Abs(_vertical), Mathf.Abs(_horizontal)) + 0.1f, 1);
                _animator.SetBool("Running", true);
            }
            else
            {
                _animator.speed = 1;
                _animator.SetBool("Running", false);
            }

        }
        else
        {
            _animator.speed = 1;
            //jumping = true;
        }
    }
    private void jump()
    {

        if (slope) return;
        if (inWater) return;
        if (_timeSinceGrounded > _coyoteTime) return;

        //GetComponent<Animator>().Play("Jumping", -1, 0);
        jumping = true;
        _timeSinceGrounded = 1;
        _currentFallSpeed = 3;
        _moveDirection.y = _jumpForce;
        _jumpingTime = 0.5f;
        //AudioManager.PlayJump();
        _animator.SetBool("Jump", true);
    }
    /*void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb != null && !rb.isKinematic)
        {
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            rb.AddForce(pushDir * 5f, ForceMode.Impulse);
            Debug.Log("Pushed " + hit.collider.name);
        }
    }*/
}