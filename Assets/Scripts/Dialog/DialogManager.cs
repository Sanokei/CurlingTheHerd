using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
public class DialogManager : MonoBehaviour
{
    [Header("Dialog UI")]
    [SerializeField]
    private GameObject dialogPanel;
    [SerializeField]
    private TextMeshProUGUI dialogText;
    [SerializeField]
    private TextMeshProUGUI dialogName;
    [SerializeField]
    private GameObject[] dialogChoices;
    private TextMeshProUGUI[] dialogChoiceTexts;
    private Story currentStory;
    public static DialogManager instance;
    public bool dialogIsPlaying {get; private set;}
    
    public event Action onDialogEnd;
    public event Action onCutSceneTag;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static DialogManager GetInstance()
    {
        return instance;
    }
    
    void Start()
    {
        dialogIsPlaying = false;
        dialogPanel.SetActive(false);

        dialogChoiceTexts = new TextMeshProUGUI[dialogChoices.Length];
        int index = 0;
        foreach (GameObject choice in dialogChoices)
        {
            dialogChoiceTexts[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }
    private void Update()
    {
        if (dialogIsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
            {
                ContinueStory();
            }
        }
    }
    public void ContinueStory()
    {
        if(currentStory.canContinue)
        {
            dialogText.text = currentStory.Continue();
            DisplayChoices();
            HandleTags(currentStory.currentTags);
        }
        else{
            StartCoroutine(ExitDialogMode());
        }
    }

    public void EnterDialogMode(TextAsset inkAsset)
    {
        currentStory = new Story(inkAsset.text);
        dialogIsPlaying = true;
        dialogPanel.SetActive(true);
        ContinueStory();
        
    }

    private IEnumerator ExitDialogMode()
    {
        yield return new WaitForSeconds(0.2f);
        dialogIsPlaying = false;
        dialogPanel.SetActive(false);
        dialogText.text = "";
        if(onDialogEnd != null)
        {
            onDialogEnd();
        }
    }

    private void DisplayChoices(){
        List<Choice> currentChoices = currentStory.currentChoices;
        if(currentChoices.Count > dialogChoices.Length)
        {
            Debug.LogError("Too many choices to display");
            return;
        }
        int index = 0;
        foreach(Choice choice in currentChoices)
        {
            dialogChoices[index].SetActive(true);
            dialogChoiceTexts[index].text = choice.text;
            index++;
        }
        for(int i = index; i < dialogChoices.Length; i++)
        {
            dialogChoices[i].SetActive(false);
        }
        //StartCoroutine(SelectFirstChoice());
    }

    // private IEnumerator SelectFirstChoice()
    // {
    //     /*
    //     unity's event system is jank
    //     so you gotta clear is first
    //     then wait
    //     then you can set the current selected
    //     weird but it works
    //     */
    //     EventSystem.current.SetSelectedGameObject(null);
    //     yield return new WaitForEndOfFrame();
    //     EventSystem.current.SetSelectedGameObject(dialogChoices[0].gameObject);
    // }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    private void HandleTags(List<string> tags)
    {
        foreach(string tag in tags)
        {
            string[] tagSplit = tag.Split(':');
            if(tagSplit.Length != 2)
            {
                Debug.LogError("Tag is not formatted correctly");
            }
            string tagKey = tagSplit[0].Trim();
            string tagValue = tagSplit[1].Trim();

            switch(tagKey)
            {
                case "speaker":
                    dialogName.text = tagValue;
                    break;
                 case "cutscene":
                    if(onCutSceneTag != null)
                    {
                        onCutSceneTag();
                    }
                    break;
            }
        }
    }

}
