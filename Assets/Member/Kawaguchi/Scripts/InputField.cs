using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputNameField : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEngine.UI.InputField _player1Field;
    [SerializeField] private UnityEngine.UI.InputField _player2Field;
    [SerializeField] Ranking _ranking;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(PlayerNameDecision(() => SceneLoader.ChangeScene("InGame")));
    }

    public IEnumerator PlayerNameDecision(Action action)
    {
        yield return StartCoroutine(_ranking.PostDataAsync(_player1Field.text, 0, null));
        yield return StartCoroutine(_ranking.PostDataAsync(_player2Field.text, 0, null));
        action();
    }
}
