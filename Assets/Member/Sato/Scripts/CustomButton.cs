using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// �K����Image��Button�Ƃ��Ĉ����B
/// ���쎞�̉����Đ��A�{�^���̑傫����ς��鉉�o�t���B
/// </summary>
[RequireComponent(typeof(Image))]
public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler,
    IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    const float OnHoverSize = 1.05f;
    const float OnPushSize = 0.95f;

    /// <summary>
    /// OnClick���ɌĂ΂�鏈���B
    /// </summary>
    public event UnityAction OnClick;

    // �f�t�H���g�̑傫���ɔ{������Z���đ傫����ς���B
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

    // �u���ɑ傫����ς���B
    void ChangeScale(float size)
    {
        transform.localScale = _defaultScale * size;
    }
}
