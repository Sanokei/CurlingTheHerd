using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Death : MonoBehaviour
{
    public Image HealthBar;
    public GameObject bruh, score;
    private TextMeshProUGUI Score;
    // Start is called before the first frame update
    void Start()
    {
        
        HealthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        bruh = GameObject.Find("Bruh");
        Score = score.GetComponent<TextMeshProUGUI>();
        bruh.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     if(HealthBar.fillAmount <= 0)
        {
            bruh.SetActive(true);
            //set the text to say the score
            Score.text = "Score: " + GoalManager.goalsScored;
            GoalManager.Dead = true;
        }
    }
}
