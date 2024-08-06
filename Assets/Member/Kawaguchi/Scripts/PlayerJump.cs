using UnityEngine;

public class PlayerJump : MonoBehaviour
{
	[SerializeField] private float _jumpPower;
	[SerializeField] private PlayerInput _playerInput;

	[SerializeField] private Rigidbody _rb;
	private Vector3 _dir;
	private Vector3 _savePos;

	private float _currentJumpPower;
	private bool _isGround;


	private void Start()
	{
		Initialize();
	}

	private void Update()
	{
		if (Input.GetKeyDown(_playerInput.JumpKey) && _isGround) Jump();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Ground") && _rb.velocity.y < 0) _isGround = true;
	}

	private void Initialize()
	{
		_currentJumpPower = _jumpPower;
	}

	//右左ジャンプ
	private void Jump()
	{
		_isGround = false;
		_rb.AddForce(Vector3.up * _currentJumpPower, ForceMode.Impulse);
	}

	public void JumpPowerUp(float value)
	{
		_currentJumpPower *= value;
	}

	public void JumpPowerReturn()
	{
		_currentJumpPower = _jumpPower;
	}
}
