using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPausePanel : UIDisplay
{
    protected static UIPausePanel instance;
    public static UIPausePanel Instance => instance;
    public bool IsPaused { get; protected set; }
    protected override void Awake()
    {
        base.Awake();
        if (UIPausePanel.instance != null) Debug.LogWarning("Only 1 UIPausePanel allow to axist");
        UIPausePanel.instance = this;
    }

    public override void Open()
    {
        base.Open();
        IsPaused = true;
    }

    public override void Close()
    {
        base.Close();
        IsPaused = false;
    }

    public void TogglePause()
    {
        if (IsPaused)
        {
            AudioManager.Instance.SetFootStepSource(true);
            this.Close();
        }
        else
        {
            AudioManager.Instance.SetFootStepSource(false);
            this.Open();
        }
    }
}
