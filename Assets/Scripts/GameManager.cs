using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;
    public int ammoAmmount;
    public int healthAmmount;
    public bool isReloading;
    private void Awake(){
        current = this;
    }
    public event Action onAmmoChange;
    public void Shoot(int ammoAmmount){
        this.ammoAmmount = ammoAmmount;
        if(onAmmoChange != null){
            onAmmoChange();
        }

    }
    public void Reload(int ammoAmmount, bool isReloading = false){ //cant leave ammoAmount ambigous with a default value
        this.ammoAmmount = ammoAmmount;
        this.isReloading = isReloading;
        if(onAmmoChange != null){
            onAmmoChange();
        }
    }
    public void Reload(bool isReloading = false){
        this.isReloading = isReloading;
        if(onAmmoChange != null){
            onAmmoChange();
        }
    }
}
