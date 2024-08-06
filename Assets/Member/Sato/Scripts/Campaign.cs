using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Title
{
    public class Campaign : ButtonContent
    {
        protected override void OnOpenButtonClick()
        {
            SceneLoader.ChangeScene("InGame");
        }
    }
}