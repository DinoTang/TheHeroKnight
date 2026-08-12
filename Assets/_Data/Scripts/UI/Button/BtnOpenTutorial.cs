using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpenTutorial : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        UITutorial.Instance.Open();
    }
}
