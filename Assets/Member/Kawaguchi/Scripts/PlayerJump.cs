using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
	[SerializeField] private float _jumpPower;

	private PlayerInput _playerInput;
	private Rigidbody _rb;

	private Vector3 _dir;
	private Vector3 _savePos;

	private bool _isGround;
	private float _currentJumpPower;

	private void Start()
	{
		_playerInput = GetComponent<PlayerInput>();
		_rb = GetComponent<Rigidbody>();
		Initialize();
	}

	void Initialize()
	{
		_currentJumpPower = _jumpPower;
	}

	private void Update()
	{
		if (Input.GetKeyDown(_playerInput.JumpKey) )
		{
			Jump();
		}
	}

	//右左ジャンプ
	private void Jump()
	{
		_isGround = false;
		_rb.AddForce(Vector3.up * _currentJumpPower, ForceMode.Impulse);
	}

	private void OnTriggerEnter(Collider other)
	{
		_isGround = true;
	}

	public void JumpPowerUp(float value)
	{
		_currentJumpPower *= value;
	}

	public void JumpPowerDown()
	{
		_currentJumpPower = _jumpPower;
	}
}
