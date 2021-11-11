using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    Button Startbutton, Creditsbutton, Exitbutton;
    [SerializeField]
    RectTransform fader;
    // Start is called before the first frame update
    void Start()
    {
        fader.gameObject.SetActive(false);
        LeanTween.scale(fader, new Vector3(1,1,1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() => {
            fader.gameObject.SetActive(false);
        });
        Startbutton = GameObject.Find("Start Button").GetComponent<Button>();
        Startbutton.onClick.AddListener(delegate {GoToGameScene("CurlingTheHerd");});
        Creditsbutton = GameObject.Find("Credits Button").GetComponent<Button>();
        Creditsbutton.onClick.AddListener(delegate {GoToGameScene("Credits");});
        Exitbutton = GameObject.Find("Exit Button").GetComponent<Button>();
        Exitbutton.onClick.AddListener(() => {Application.Quit();});
    }

    public void GoToGameScene(string sceneName){
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1,1,1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() => { 
            SceneManager.LoadScene(sceneName);
        });
    }
}
