using UnityEngine;

public class PlayerJump : MonoBehaviour
{
	[SerializeField] private float _jumpPower;
	[SerializeField] private PlayerInput _playerInput;

	[SerializeField] private Rigidbody _rb;
	private Vector3 _dir;
	private float _saveHight;

	private float _currentJumpPower;
	private bool _isGround;



	private void Start()
	{
		Initialize();
	}

	private void Update()
	{
		if (Input.GetKeyDown(_playerInput.JumpKey) && _isGround) Jump();
		ScoreManager.SetScore((int)(this.transform.position.y - _saveHight));
	}
    private void LateUpdate()
    {
        if(this.transform.position.z != 0) transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Ground") && _rb.velocity.y <= 0) _isGround = true;
	}

	private void Initialize()
	{
		_currentJumpPower = _jumpPower;
        _saveHight = this.transform.position.y;

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
