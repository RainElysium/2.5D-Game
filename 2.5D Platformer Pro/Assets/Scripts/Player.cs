using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 15f;
    private float _yVelocity;
    private bool _canDoubleJump;
    [SerializeField]
    private int _lives = 3;
    private UIManager _uiManager;
    private Vector3 _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        _uiManager.UpdateLivesVisual(3);
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump)
            {
                _yVelocity += _jumpHeight * 1.5f;
            }
            _yVelocity -= _gravity; // falling
        }

        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);

        if (_lives == 0)
            _lives = 3;
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= -5.00f)
        {
            transform.position = _startPosition;
            --_lives;
            _uiManager.UpdateLivesVisual(_lives);
        }
    }
}
