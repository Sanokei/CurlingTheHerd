using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    private PlayableDirector director;
    public GameObject controlPanel;

    void Awake()
    {
        director = GetComponent<PlayableDirector>();
        director.played += Director_Played;
        director.stopped += Director_Stopped;
        
    }
    void Start()
    {
        DialogManager.GetInstance().onCutSceneTag += PlayCutScene;
    }

    void PlayCutScene()
    {
        //play animation
        director.Play();

    }
    private void Director_Played(PlayableDirector obj)
    {
        controlPanel.SetActive(false);
    }
    private void Director_Stopped(PlayableDirector obj)
    {
        controlPanel.SetActive(true);
    }
}
