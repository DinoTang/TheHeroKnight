using UnityEditor;
using UnityEngine;

public class BtnQuit : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        Debug.Log("Thoat Game");
        Application.Quit();
    }
}
