using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// 適当なImageをButtonとして扱う。
/// 操作時の音を再生、ボタンの大きさを変える演出付き。
/// </summary>
[RequireComponent(typeof(Image))]
public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler,
    IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    const float OnHoverSize = 1.05f;
    const float OnPushSize = 0.95f;

    /// <summary>
    /// OnClick時に呼ばれる処理。
    /// </summary>
    public event UnityAction OnClick;

    // デフォルトの大きさに倍率を乗算して大きさを変える。
    Vector3 _defaultScale;

    void Awake()
    {
        _defaultScale = transform.localScale;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        AudioPlayer.PlaySE("SE_ButtonSubmit");
        OnClick?.Invoke();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        ChangeScale(OnHoverSize);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        ChangeScale(1);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        ChangeScale(OnPushSize);
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        ChangeScale(OnHoverSize);
    }

    // 瞬時に大きさを変える。
    void ChangeScale(float size)
    {
        transform.localScale = _defaultScale * size;
    }
}
