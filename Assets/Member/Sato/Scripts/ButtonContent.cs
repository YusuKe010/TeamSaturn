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
    /// Startのタイミングで呼ぶ処理。
    /// </summary>
    protected virtual void OnStart() { }

    /// <summary>
    /// 開くボタンをクリックしたときの処理。
    /// </summary>
    protected abstract void OnOpenButtonClick();
}