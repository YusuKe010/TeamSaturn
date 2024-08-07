using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private KeyCode _jumpKey = KeyCode.Space;
	[SerializeField] private KeyCode _leftKey = KeyCode.A;
	[SerializeField] private KeyCode _rightKey = KeyCode.D;
	public KeyCode JumpKey => _jumpKey;
	public KeyCode LeftKey => _leftKey;
	public KeyCode RightKey => _rightKey;

	public float InputValue { get; private set; }

	bool _isStart;
	public bool IsStart => _isStart;

	private void Update()
	{
		InputValue = Input.GetAxis("Horizontal");
	}

	public void PlayerStart()
	{
		_isStart = true;
	}
	public void PlayerEnd()
	{
		_isStart = false;
	}
}
