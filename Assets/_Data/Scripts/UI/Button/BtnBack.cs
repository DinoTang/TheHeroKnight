using UnityEditor;
using UnityEngine;

public class BtnBack : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        UISettings.Instance.Close();

        UIPausePanel uIPausePanel = UIPausePanel.Instance;
        if (uIPausePanel != null)
        {
            InputManager.Instance.IsEscape = true;
            uIPausePanel.Open();
        }
    }
}
