using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private KeyCode _jumpKey = KeyCode.Space;
	[SerializeField] private KeyCode _leftKey = KeyCode.A;
	[SerializeField] private KeyCode _rightKey = KeyCode.D;
	public KeyCode JumpKey => _jumpKey;
	public KeyCode LeftKey => _leftKey;
	public KeyCode RightKey => _rightKey;

	public float _inputValue;
	public float InputValue => _inputValue;

	bool _isStart;
	public bool IsStart => _isStart;


    private void Update()
	{
		if (Input.GetKey(_leftKey))
		{
			_inputValue = -1;
		}
		else if (Input.GetKey(_rightKey))
		{
			_inputValue = 1;
		}
        else
        {
			_inputValue = 0;
        }
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
