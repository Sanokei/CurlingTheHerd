using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
    private GameObject player;
    private bool startAttackPlayer = false;
    private Rigidbody2D rb;
    void Start(){
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate(){
        //Use Vector2 to look towards the player
        if(startAttackPlayer || GoalManager.playerNotSeenTime > GoalManager.playerNotSeenTimeMax){
            Vector2 direction = -((Vector2)transform.position - ((Vector2)player.transform.position + new Vector2(10,10)));
            transform.up = direction;

            //go towards the player
            if(Random.Range(0,100) < GoalManager.goalAttackChance){
                rb.AddForce(direction * GoalManager.goalSpeed);
            }
        }
    }
    // Update is called once per frame
    public void goTowardsPlayer(OnTriggerDelegation delegation)
    {
       startAttackPlayer = true;
    }
}
