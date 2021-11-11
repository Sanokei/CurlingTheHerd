using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBehave : MonoBehaviour
{
    [SerializeField]
    private GameObject Light;
    [SerializeField]
    private GameObject Light_off;
    [SerializeField]
    private GameObject Light_on;
    [SerializeField]
    private GameObject Explosion;
    private GameObject fader;
    private GameObject bruh;
    private bool changed;
    private Image HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        //
        Light.SetActive(false);
        Light_on.SetActive(false);
        Explosion.SetActive(false);

        changed = false;
    }
    void Update()
    {
        if(!changed || GoalManager.playerNotSeenTime > GoalManager.playerNotSeenTimeMax){
            Light_off.SetActive(true);
            Light_on.SetActive(false);
            Light.SetActive(false);
            changed = false;
            GoalManager.playerNotSeenTime = 0f;
        }
        else{
            GoalManager.playerNotSeenTime += Time.deltaTime;
        }
    }
    public void ChangeLight(OnTriggerDelegation delegation)
    {
        changed = true;
        Light_off.SetActive(false);
        Light_on.SetActive(true);
    }
    public void initiateSelfDestructSequence(OnTriggerDelegation delegation)
    {
        if(delegation.Other.tag == "Bullet"){
            Light_off.SetActive(false);
            Light_on.SetActive(false);
            StartCoroutine(SelfDestruct());
        }
    }
    IEnumerator SelfDestruct()
    {
        Light.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        Explosion.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        // GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        // foreach(GameObject bullet in bullets){
        //     Destroy(bullet);
        // }
        Destroy(gameObject);
        GoalManager.goalsScored++;
    }

    public void playerDestruction(OnTriggerDelegation delegation)
    {
        if(delegation.Other.tag == "Player"){
            HealthBar.fillAmount -= 0.25f;
        }
    }

    public void bulletDestruction(OnTriggerDelegation delegation)
    {
        if(delegation.Other.tag == "Bullet" || delegation.Other.tag == "Enemy"){
            Destroy(delegation.Other.gameObject);
            HealthBar.fillAmount += 0.005f;
        }
    }
}
