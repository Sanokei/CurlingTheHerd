using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAmmoAmmount : MonoBehaviour
{
    void Start()
    {
        GameManager.current.onAmmoChange += ChangeAmmo;
    }
    
    public void ChangeAmmo(){ //making it null just makes it a None spite
        GetComponent<SpriteRenderer>().sprite = GameManager.current.ammoAmmount <= 0 ? null : GameManager.current.ammoAmmount >= 16 ? Resources.LoadAll<Sprite>("Sprites/Ammo")[15] as Sprite : Resources.LoadAll<Sprite>("Sprites/Ammo")[GameManager.current.ammoAmmount-1] as Sprite;
    }
}
