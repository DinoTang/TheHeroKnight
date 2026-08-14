using UnityEngine;

public class UIWinPanel : UIDisplay
{
    protected static UIWinPanel instance;
    public static UIWinPanel Instance => instance;
    public bool IsPaused { get; protected set; }
    protected override void Awake()
    {
        base.Awake();
        if (UIWinPanel.instance != null) Debug.LogWarning("Only 1 UIWinPanel allow to axist");
        UIWinPanel.instance = this;
    }
}