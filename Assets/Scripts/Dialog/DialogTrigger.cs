using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private bool playerInRange;
    private void Awake()
    {
        if (visualCue != null)
        {
            playerInRange = false;
            visualCue.SetActive(false);
        }
    }
    private void Update()
    {
        if (visualCue != null)
        {
            if (playerInRange && !DialogManager.GetInstance().dialogIsPlaying)
            {
                visualCue.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
                {
                    DialogManager.GetInstance().EnterDialogMode(inkJSON);
                }
            }
            else
            {
                visualCue.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        playerInRange = playerCollider.gameObject.CompareTag("Player") ? true : false;
    }

    private void OnTriggerExit2D(Collider2D playerCollider)
    {
        playerInRange = playerCollider.gameObject.CompareTag("Player") ? false : true;
    }
}
