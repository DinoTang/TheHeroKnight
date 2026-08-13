using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDash : BaseBehavior
{
    [SerializeField] private Image cooldownOverlay;
    [SerializeField] private TMP_Text cooldownText;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCooldownOverlay();
        this.LoadCooldownText();
    }

    protected void LoadCooldownOverlay()
    {
        if (cooldownOverlay != null) return;
        cooldownOverlay = GetComponentInChildren<UICooldownOverlay>().GetComponent<Image>();
        Debug.Log(transform.name + " LoadCooldownOverlay");
    }

    protected void LoadCooldownText()
    {
        if (cooldownText != null) return;
        cooldownText = GetComponentInChildren<UICooldownText>().GetComponent<TMP_Text>();
        Debug.Log(transform.name + " LoadCooldownText");
    }

    public void Update()
    {
        if (PlayerCtrl.Instance.PlayerDash == null) return;

        float cooldownTimer = PlayerCtrl.Instance.PlayerDash.CooldownTimer;
        float cooldownTime = PlayerCtrl.Instance.PlayerDash.DashingCooldown;

        if (cooldownTimer > 0f)
        {
            float progress = cooldownTimer / cooldownTime;
            cooldownOverlay.fillAmount = progress;
            
            cooldownText.text = cooldownTimer.ToString("F1");
        }
        else
        {
            cooldownOverlay.fillAmount = 0f;
            cooldownText.text = "";
        }
    }
}