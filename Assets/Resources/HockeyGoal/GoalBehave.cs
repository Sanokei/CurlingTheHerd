using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehave : MonoBehaviour
{
    private GameObject player;
    private bool startAttackPlayer = false;
    private Rigidbody2D rb;
    void Start(){
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        startAttackPlayer = true;
    }
    void FixedUpdate(){
        //Use Vector2 to look towards the player
        if(startAttackPlayer || GoalManager.playerNotSeenTime > GoalManager.playerNotSeenTimeMax){
            Vector2 direction = -((Vector2)transform.position - ((Vector2)player.transform.position + new Vector2(10,10)));
            transform.up = direction;
            StartCoroutine(AttackPlayer(direction));
        }
    }
    IEnumerator AttackPlayer(Vector2 direction){
        if(Random.Range(0,100) < GoalManager.goalAttackChance){
                rb.AddForce(direction * GoalManager.goalSpeed);
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(0.5f,1.5f));
        }
    }
}
