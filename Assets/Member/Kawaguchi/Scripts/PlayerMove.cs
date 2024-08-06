using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] private float _moveSpeed;
	[SerializeField] private PlayerInput _playerInput;
	[SerializeField] private Rigidbody _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
		_playerInput = GetComponent<PlayerInput>();
	}

	private void FixedUpdate()
	{
		Move(new Vector3(_playerInput.InputValue * _moveSpeed, _rb.velocity.y, 0));
	}

	void Move( Vector3 dir)
	{
		_rb.velocity = dir;
	}
}
