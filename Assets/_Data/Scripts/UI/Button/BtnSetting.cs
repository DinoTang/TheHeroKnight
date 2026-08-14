using UnityEditor;
using UnityEngine;

public class BtnSetting : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        UISettings.Instance.Open();

        UIPausePanel uIPausePanel = UIPausePanel.Instance;
        if (uIPausePanel != null)
        {
            InputManager.Instance.IsEscape = false;
            uIPausePanel.Close();
        }
    }
}
