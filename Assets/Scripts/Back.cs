using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    Button Backbutton;
    
    // Start is called before the first frame update
    void Start()
    {
        Backbutton = GameObject.Find("Back Button").GetComponent<Button>();
        Backbutton.onClick.AddListener(delegate {GoToGameScene("Menu");});
    }

    public void GoToGameScene(string sceneName){
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
