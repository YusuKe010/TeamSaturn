using UnityEngine;

public class PlayerJump : MonoBehaviour
{
	[SerializeField] private float _jumpPower;
	[SerializeField] private PlayerController _playerInput;

	[SerializeField] private Rigidbody _rb;
	[SerializeField] ScoreManager.Player _playerType;
	[SerializeField] private ParticleSystem _playerDust;
	[SerializeField] private ParticleSystem _playerLanding;

    private Vector3 _dir;
	private float _saveHight;

	private float _currentJumpPower;
	private bool _isGround;
	private bool _isFallSE;



	private void Start()
	{
		Initialize();
	}

	private void Update()
	{
		if (Input.GetKeyDown(_playerInput.JumpKey) && _isGround && _playerInput.IsStart) Jump();
		if(!_isFallSE && _rb.velocity.y <= 0)
		{
			AudioPlayer.PlaySE("Player_Falling");
			_isFallSE = true;
		}	
	}
    private void LateUpdate()
    {
        if(this.transform.position.z != 0) transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Ground") && _rb.velocity.y <= 0) 
		{
			_isGround = true;
            //ScoreManager.SetScore(_playerType, (int)(this.transform.position.y - _saveHight));
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground") && _rb.velocity.y <= 0)
        {
            AudioPlayer.PlaySE("Player_Landing");
            _playerLanding.Play();
        }

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
		_isFallSE = false;

        _rb.AddForce(Vector3.up * _currentJumpPower, ForceMode.Impulse);
		AudioPlayer.PlaySE("Player_Jump");
        _playerDust.Play();
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
