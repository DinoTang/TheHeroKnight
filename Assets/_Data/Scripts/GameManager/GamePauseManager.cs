using UnityEngine;

public class GamePauseManager : BaseBehavior
{
    protected static GamePauseManager instance;
    public static GamePauseManager Instance => instance;
    public bool IsPaused { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (GamePauseManager.instance != null) Debug.LogWarning("Only 1 GamePauseManager allow exist");
        GamePauseManager.instance = this;
    }

    public void Pause()
    {
        IsPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        IsPaused = false;
        Time.timeScale = 1f;
    }

    public void TogglePause()
    {
        if (IsPaused)
            this.Resume();
        else
            this.Pause();
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}