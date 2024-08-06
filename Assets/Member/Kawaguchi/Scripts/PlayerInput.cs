using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.SpriteAssetUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	[SerializeField] private KeyCode _jumpKey = KeyCode.Space;
	[SerializeField] private KeyCode _leftKey = KeyCode.A;
	[SerializeField] private KeyCode _rightKey = KeyCode.D;
	private float _inputValue;
	public KeyCode JumpKey => _jumpKey;
	public KeyCode LeftKey => _leftKey;
	public KeyCode RightKey => _rightKey;

	public float InputValue => _inputValue;

	private void Update()
	{
		_inputValue = Input.GetAxis("Horizontal");
	}
}
