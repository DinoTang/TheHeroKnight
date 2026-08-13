using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplay : BaseBehavior
{
    protected override void Start()
    {
        base.Start();
        this.Close();
    }
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }
}
