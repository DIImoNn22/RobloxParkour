using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour 
{
	[Header("vars")]
	private Vector3 _playerVelocity;
	public float speed = 2.0f;
	public float jumpHeight = 1.0f;
	public float turnSpeed = 300.0f;
	public float gravityValue = -9.81f;

	[Header("Check Point")]
	public Vector3 _savedPosition;

	[Header("Jump")]
	public LayerMask groundLayer;
	public Transform groundChecker;
	public float distToGround = 0.2f;

    public bool GroundedPlayer => Physics.Raycast(groundChecker.position, Vector3.down, distToGround, groundLayer);

	private CharacterController _controller;
	private Animator _anim;

    private void Start()
	{
        _controller = GetComponent<CharacterController>();
        _anim = GetComponentInChildren<Animator>();

        _savedPosition = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));
        this.transform.position = _savedPosition;
    }

	void Update()
	{
        var turn = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

        Vector3 move = transform.forward * (Input.GetAxisRaw("Vertical") * speed);
        _controller.Move(move * (Time.deltaTime * speed));

        // --- JUMPING ---
        if (GroundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        _anim.SetBool("IsInAirEnd", !GroundedPlayer);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        _playerVelocity.y += gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }
	
	private void Jump()
	{
		if (GroundedPlayer)
		{
			_playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
			_anim.SetTrigger("Jump");
		}
	}
}
