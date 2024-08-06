using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Title
{
    public class Option : TitleContent
    {
        [SerializeField] GameObject _option;
        [SerializeField] Button _closeButton;

        void Awake()
        {
            Close();
        }

        protected override void OnStart()
        {
            _closeButton.onClick.AddListener(Close);
        }

        protected override void OnOpenButtonClick()
        {
            Open();
        }

        // ŠJ‚­B
        private void Open() => _option.SetActive(true);

        // •Â‚¶‚éB
        private void Close() => _option.SetActive(false);
    }
}