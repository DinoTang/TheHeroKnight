using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnHome : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }
}
