using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EndTutorial: MonoBehaviour
{
    private GameObject player, gate;
    GameObject enemy;
    [SerializeField]
    GameObject ENEMYPREFAB;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gate = GameObject.Find("Gate");
    }

    // Update is called once per frame
    void Update()
    {
        if(GoalManager.goalsScored == 1)
        {
            GoalManager.Tutorial = false;
            PlayerPrefs.SetInt("Tutorial", 0);
            gate.SetActive(true);
            player.transform.position = new Vector2(7, -55);
        }
        if(!GoalManager.Tutorial){
            Debug.Log(GoalManager.goalsTotal);
            Debug.Log(GoalManager.goalsScored);
            if(GoalManager.goalsTotal <= GoalManager.goalsScored){
                StartCoroutine(spawnEnemy());
                GoalManager.goalsTotal++;
            }
            
        }
    }

    IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(Random.Range(0,2));
        //get random position in play area using camera bounds
        float x = Random.Range(Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).x, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x);
        float y = Random.Range(Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).y, Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0)).y);
        enemy = Instantiate(ENEMYPREFAB, new Vector2(x + player.transform.position.x,y + player.transform.position.y), Quaternion.identity) as GameObject;
        //enemy = PrefabUtility.InstantiatePrefab(Resources.Load("HockeyGoal/HockeyGoal") as GameObject) as GameObject;
        //enemy.transform.position = pos;
    }
}
