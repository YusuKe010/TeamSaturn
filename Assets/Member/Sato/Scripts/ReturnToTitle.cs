using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToTitle : ButtonContent
{
    protected override void OnOpenButtonClick()
    {
        SceneLoader.ChangeScene("Title");
    }
}
