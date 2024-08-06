using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	[SerializeField] private KeyCode _jumpKey = KeyCode.Space;
	[SerializeField] private KeyCode _leftKey = KeyCode.A;
	[SerializeField] private KeyCode _rightKey = KeyCode.D;
	public KeyCode JumpKey => _jumpKey;
	public KeyCode LeftKey => _leftKey;
	public KeyCode RightKey => _rightKey;

	public float InputValue { get; private set; }

	private void Update()
	{
		InputValue = Input.GetAxis("Horizontal");
	}
}
