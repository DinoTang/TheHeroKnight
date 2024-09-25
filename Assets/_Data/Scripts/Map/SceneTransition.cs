using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : DinoBehaviourScript
{
    [SerializeField] protected SceneName sceneName;
    [SerializeField] protected Vector2 playerPos;
    [SerializeField] protected SceneSO playerStorage;
    [SerializeField] protected PlayerHpSO playerHpSO;
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected Animator transAnim;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.playerPos.x = -16;
        this.playerPos.y = 3;
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.SetHp();
            this.SetPos();
            this.SetInventory();
            this.NextLevel();
        }
    }
    protected void SetHp()
    {
        this.playerHpSO.currentHp = PlayerCtrl.Instance.PlayerDamReceive.Hp;
    }
    protected void SetPos()
    {
        this.playerStorage.intialValue = playerPos;
    }
    protected void SetInventory()
    {
        this.inventory.ClearInventory();
        this.inventory.SaveItems();
    }
    protected void NextLevel()
    {
        StartCoroutine(this.LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        this.StopPlayerMovement();
        this.transAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(this.sceneName.ToString());
        this.transAnim.SetTrigger("Start");
    }
    protected void StopPlayerMovement()
    {
        PlayerCtrl.Instance.PlayerMovement._Rb.constraints = RigidbodyConstraints2D.FreezeAll;
        PlayerCtrl.Instance.PlayerMovement.enabled = false;
        PlayerCtrl.Instance.PlayerMovement.SetHorizontal(0);
        PlayerCtrl.Instance.PlayerMovement.SetVertical(0);
        PlayerCtrl.Instance.PlayerAttack.enabled = false;
    }
}
