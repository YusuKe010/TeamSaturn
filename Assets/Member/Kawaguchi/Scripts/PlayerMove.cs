using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] private float _moveSpeed;
	[SerializeField] private PlayerInput _playerInput;
	[SerializeField] private Rigidbody _rb;
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
