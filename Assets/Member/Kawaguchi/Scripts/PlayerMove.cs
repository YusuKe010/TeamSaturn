using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] private float _moveSpeed;
	private PlayerInput _playerInput;
	private Rigidbody _rb;
	private Vector3 _dir;

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
		_playerInput = GetComponent<PlayerInput>();
	}

	private void FixedUpdate()
	{
		_dir = new Vector3(_playerInput.InputValue * _moveSpeed, _rb.velocity.y, 0);
		_rb.velocity = _dir;
	}
}
