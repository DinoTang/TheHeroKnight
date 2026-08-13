using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpBarPlayer : HpBar
{
    [Header("Hp Bar Player")]
    [SerializeField] protected TMP_Text uiHpCountText;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIHpCountText();
    }

    protected void LoadUIHpCountText()
    {
        if (this.uiHpCountText != null) return;
        this.uiHpCountText = GetComponentInChildren<UIHpCountText>().GetComponent<TMP_Text>();
        Debug.Log(transform.name + ": LoadUIHpCountText", gameObject);
    }

    protected override void HpShowing()
    {
        this.hp = PlayerCtrl.Instance.PlayerDamReceive.Hp;
        this.hpMax = PlayerCtrl.Instance.PlayerDamReceive.HPMax;

        this.uiHpCountText.text = $"{this.hp}/{this.hpMax}";

        base.HpShowing();
    }

}