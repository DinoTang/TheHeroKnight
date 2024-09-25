using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnStartGame : BaseButton
{
    [Header("BtnStartGame")]
    [SerializeField] protected Animator transAnim;
    [SerializeField] protected Canvas canvas;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(this.StartMenuGame());
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTransAnim();
    }
    protected void LoadTransAnim()
    {
        if (this.transAnim != null) return;
        this.transAnim = transform.parent.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadTransAnim", gameObject);
    }
    protected override void OnClick()
    {
        this.PlayGame();
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
