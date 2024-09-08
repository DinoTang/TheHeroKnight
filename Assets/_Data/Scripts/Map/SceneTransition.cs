using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : DinoBehaviourScript
{
    [SerializeField] protected SceneName sceneName;
    [SerializeField] protected Vector2 playerPos;
    [SerializeField] protected VectorValue playerStorage;
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
            this.playerStorage.intialValue = playerPos;
            SceneManager.LoadScene(this.sceneName.ToString());
        }
    }
}
