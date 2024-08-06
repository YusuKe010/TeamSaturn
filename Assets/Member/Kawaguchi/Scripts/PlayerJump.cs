using UnityEngine;

public enum PlayerPlaceState
{
	Left,
	Right
}

public class PlayerJump : MonoBehaviour
{
	[SerializeField] private KeyCode _jump = KeyCode.Space;
	[SerializeField] private KeyCode _left = KeyCode.A;
	[SerializeField] private KeyCode _right = KeyCode.D;
	[SerializeField] private Vector3 _rightDir;
	[SerializeField] private Vector3 _leftDir;
	[SerializeField] private Vector3 _centerDir;
	[SerializeField] private Vector3 _fallDir;
	
	private Rigidbody _rb;
	
	private Vector3 _dir;
	private PlayerPlaceState _playerState;
	private Vector3 _savePos;
	
	private bool _isGround;

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (Input.GetKey(_jump) && _isGround)
		{
			if (Input.GetKey(_left))
			{
				Jump(_left);
				_playerState = PlayerPlaceState.Left;
			}
			else if (Input.GetKey(_right))
			{
				Jump(_right);
				_playerState = PlayerPlaceState.Right;
			}
		}
	}

	private void FixedUpdate()
	{
		if (_savePos.y > transform.position.y && !_isGround)
		{
			_dir = _fallDir;
			_rb.velocity = _dir;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Ground"))
		{
			_isGround = true;
			_savePos = transform.position;
			_savePos.y -= 0.5f;
		}
	}

	//右左ジャンプ
	private void Jump(KeyCode key)
	{
		_isGround = false;
		switch (_playerState)
		{
			//左にいる時に左ジャンプした場合は上ジャンプ、右ジャンプをした場合は左ジャンプ
			case PlayerPlaceState.Left:
				_dir = key == _left ? _centerDir : _rightDir;
				break;
			//右にいる時に左ジャンプした場合は左ジャンプ、右ジャンプをした場合は上ジャンプ
			case PlayerPlaceState.Right:
				_dir = key == _left ? _leftDir : _centerDir;
				break;
		}

		_rb.velocity = _dir;
	}
}
