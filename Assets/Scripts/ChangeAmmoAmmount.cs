using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAmmoAmmount : MonoBehaviour
{
    void Start()
    {
        GameManager.current.onAmmoChange += ChangeAmmo;
    }
    public void ChangeAmmo(){
        Debug.Log(GameManager.current.ammoAmmount);
        if(GameManager.current.ammoAmmount == 0){
            gameObject.SetActive(false);
        }
        else{
            gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Sprites/Ammo")[GameManager.current.ammoAmmount-1] as Sprite;
        }
    }
}
