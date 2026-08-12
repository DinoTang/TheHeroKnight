using UnityEngine;
using UnityEngine.UI;

public class UIFire : BaseBehavior
{
    public Image image;
    public Sprite[] frames;
    public float fps = 10f;

    private int currentFrame;

    protected override void Start()
    {
        InvokeRepeating(nameof(NextFrame), 0, 1f / fps);
    }

    private void NextFrame()
    {
        currentFrame++;

        if (currentFrame >= frames.Length)
            currentFrame = 0;

        image.sprite = frames[currentFrame];
    }
}