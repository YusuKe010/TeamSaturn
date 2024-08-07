using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.InputField _player1Field;
    [SerializeField] private UnityEngine.UI.InputField _player2Field;
    [SerializeField] Ranking _ranking;
    public void PlayerNameDecision()
    {
        _ranking.PostData(_player1Field.text, 0, null);
        _ranking.PostData(_player2Field.text, 0, null);
    }
}
