using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonContent : MonoBehaviour
{
    [SerializeField] Button _openButton;

    void Start()
    {
        _openButton.onClick.AddListener(OnOpenButtonClick);
        OnStart();
    }

    /// <summary>
    /// Start�̃^�C�~���O�ŌĂԏ����B
    /// </summary>
    protected virtual void OnStart() { }

    /// <summary>
    /// �J���{�^�����N���b�N�����Ƃ��̏����B
    /// </summary>
    protected abstract void OnOpenButtonClick();
}