using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropData : MonoBehaviour  {
    public abstract void OnDropInteract(); 
    //Mana , Beserker , Health
    //int manaAmount int healthAmount float berserkerDamageIncrease float berserkerDamageTime
    private GameObject playerGameObject;
    private const float DEATH_DELAY = 5f;
    private void Awake()
    {
        playerGameObject = PlayerManager.Instance.GetPlayer();
    }

    public GameObject getPlayerGameObject() 
    {
    return playerGameObject;
    }
    public void setPlayerGameObject(GameObject newPlayergameObject)
    {
    this.playerGameObject = newPlayergameObject;
    }

    public void WaitToDie()
    {
        StartCoroutine(WaitThenDie(DEATH_DELAY));
    }
    public void WaitToDie(float deathDelay) {
        StartCoroutine(WaitThenDie(deathDelay));
    }
    private IEnumerator WaitThenDie(float secondsToWait)
    {
       var sr = GetComponent<SpriteRenderer>();
        var col = GetComponent<Collider2D>();
        if (sr)
            sr.enabled = false;
        if (col)
            col.enabled = false;

        yield return new WaitForSeconds(secondsToWait);
        Destroy(this.gameObject);
    }
}
