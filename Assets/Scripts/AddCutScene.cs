using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCutScene : MonoBehaviour
{
    GameObject reticle;
    // Start is called before the first frame update
    void Start()
    {
        DialogManager.GetInstance().onCutSceneTag += playCutScene;
        reticle = GameObject.Find("Custom Cursor");
    }

    public void playCutScene(){
        StartCoroutine(playCutSceneCoroutine());
    }

    IEnumerator playCutSceneCoroutine(){
        reticle.SetActive(false);
        Camera.main.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2f);
        Camera.main.GetComponent<Animator>().enabled = false;
        reticle.SetActive(true);
    }
}
