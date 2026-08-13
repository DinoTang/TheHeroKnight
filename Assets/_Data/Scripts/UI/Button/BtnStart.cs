using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnStart : BaseButton
{
    [Header("Btn Start")]
    [SerializeField] protected Animator transAnim;
    [SerializeField] protected Canvas canvas;
    [SerializeField] protected PlayerPos playerPosSO;
    [SerializeField] protected ArrowSO arrowSO;
    [SerializeField] protected HpPotionSO hpPotionSO;
    [SerializeField] protected PlayerHpSO playerHpSO;
    protected override void Start()
    {
        base.Start();
        this.LoadComponent();
        StartCoroutine(this.StartMenuGame());
        AudioManager.Instance.OpenMusic();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerPosSO();
        this.LoadArrowSO();
        this.LoadHpPotionSO();
        this.LoadPlayerHpSO();
    }

    protected void LoadPlayerPosSO()
    {
        if (this.playerPosSO != null) return;
        this.playerPosSO = Resources.Load<PlayerPos>("GameData/PlayerPos");
        Debug.Log(transform.name + ": LoadPlayerPosSO", gameObject);
    }

    protected void LoadArrowSO()
    {
        if (this.arrowSO != null) return;
        this.arrowSO = Resources.Load<ArrowSO>("GameData/ArrowSO");
        Debug.Log(transform.name + ": LoadArrowSO", gameObject);
    }

    protected void LoadHpPotionSO()
    {
        if (this.hpPotionSO != null) return;
        this.hpPotionSO = Resources.Load<HpPotionSO>("GameData/HpPotionSO");
        Debug.Log(transform.name + ": LoadHpPotionSO", gameObject);
    }

    protected void LoadPlayerHpSO()
    {
        if (this.playerHpSO != null) return;
        this.playerHpSO = Resources.Load<PlayerHpSO>("GameData/PlayerHpSO");
        Debug.Log(transform.name + ": LoadPlayerHpSO", gameObject);
    }
    protected override void OnClick()
    {
        base.OnClick();
        this.ResetValues();
        this.PlayGame();
    }

    protected void ResetValues()
    {
        this.playerPosSO.ResetValue();
        this.arrowSO.arrowCounts = 20;
        this.hpPotionSO.hpPotionCount = 5;
        this.playerHpSO.currentHp = 100;
    }
    protected void PlayGame()
    {
        StartCoroutine(this.LoadGame());
    }
    IEnumerator LoadGame()
    {
        this.canvas.enabled = true;
        this.transAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("ForestStartScene");
    }
    IEnumerator StartMenuGame()
    {
        yield return new WaitForSeconds(1);
        this.canvas.enabled = false;
    }
}
