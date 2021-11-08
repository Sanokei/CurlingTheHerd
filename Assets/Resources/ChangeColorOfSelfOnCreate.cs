using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOfSelfOnCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        //choose a random color
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        //change the color of the object
        GetComponent<SpriteRenderer>().color = randomColor;
    }
}
