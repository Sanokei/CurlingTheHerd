using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    Button Startbutton, Creditsbutton, Exitbutton;
    // Start is called before the first frame update
    void Start()
    {
        Startbutton = GameObject.Find("Start Button").GetComponent<Button>();
        Startbutton.onClick.AddListener(delegate {GoToGameScene("CurlingTheHerd");});
        Creditsbutton = GameObject.Find("Credits Button").GetComponent<Button>();
        Creditsbutton.onClick.AddListener(delegate {GoToGameScene("Credits");});
        Exitbutton = GameObject.Find("Exit Button").GetComponent<Button>();
        Exitbutton.onClick.AddListener(() => {Application.Quit();});
    }

    public void GoToGameScene(string sceneName){
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
