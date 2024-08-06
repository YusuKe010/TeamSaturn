using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Title
{
    public class Campaign : TitleContent
    {
        protected override void OnOpenButtonClick()
        {
            SceneLoader.ChangeScene("InGame");
        }
    }
}