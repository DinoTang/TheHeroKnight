using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BtnQuitGame : BaseButton
{
    protected override void OnClick()
    {
        Debug.Log("Thoat Game");
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }
}
