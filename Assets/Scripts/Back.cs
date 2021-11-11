using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    Button Backbutton;
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
        Backbutton = GameObject.Find("Back Button").GetComponent<Button>();
        Backbutton.onClick.AddListener(delegate {GoToGameScene("Menu");});
    }

    public void GoToGameScene(string sceneName){
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1,1,1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() => { 
            SceneManager.LoadScene(sceneName);
        });
    }
}
