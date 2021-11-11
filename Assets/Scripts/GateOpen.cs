using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DialogManager.GetInstance().onDialogEnd += () => gameObject.SetActive(false);
    }
}
