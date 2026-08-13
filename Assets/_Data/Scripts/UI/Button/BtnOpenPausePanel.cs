using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpenPausePanel : BaseButton
{
    [SerializeField] protected UIPausePanel pausePanel;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIPausePanel();
    }

    protected void LoadUIPausePanel()
    {
        if (this.pausePanel != null) return;
        this.pausePanel = FindAnyObjectByType<UIPausePanel>();
        Debug.Log(transform.name + ": LoadUIPausePanel", gameObject);
    }

    protected override void OnClick()
    {
        base.OnClick();
        this.pausePanel.Open();
        GamePauseManager.Instance.Pause();
    }
}
