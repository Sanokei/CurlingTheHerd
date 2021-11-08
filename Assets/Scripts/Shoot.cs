using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private int ammountOfAmmo = 16; //add upgrades to get more ammo in the future (max 16)
    private static readonly int max_amount_of_ammo = 16;
    private Boolean isReloading = false;
    
    [SerializeField]
    private float bulletSpeed;
    private float fireElapsedTime = 0;
    [SerializeField]
    private float fireDelay = 0.2f;
    GameObject reticle;
    
    void Start()
    {
        GameManager.current.onAmmoChange += ChangeisReloading;
        reticle = GameObject.Find("Reticle");
    }
    void ChangeisReloading()
    {
        this.isReloading = GameManager.current.isReloading;
    }
    void ShootBullet(){
        GameObject bullet = Instantiate(Resources.Load("Bullet"), transform.position, transform.rotation) as GameObject;
        Vector2 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (clickedPosition - (Vector2)bullet.transform.position).normalized;
        Vector2 bulletVelocity = direction * bulletSpeed;
        bullet.GetComponent<Rigidbody2D>().AddForce(bulletVelocity, ForceMode2D.Impulse);
    }
    Color HexToColor(string hex){ //assume hex is 6 digits
        byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r,g,b, 255);
    }

    void Update(){
        fireElapsedTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0)){
            if(ammountOfAmmo > 0 && !isReloading){
                reticle.GetComponent<SpriteRenderer>().color = HexToColor("FFBA14"); //yellowish orange
                if (fireElapsedTime >= fireDelay){
                    //make shooty shoot sound
                    fireElapsedTime = 0;
                    ammountOfAmmo--;
                    ShootBullet();
                    GameManager.current.Shoot(ammoAmmount: ammountOfAmmo);
                }
            }
            else if(ammountOfAmmo > 15 && isReloading){
                //make finished reload sound
                isReloading = false;
                GameManager.current.Reload(isReloading: isReloading);
            }
            else{
                //make reloading sound
                //GetComponent<AudioSource>().Play();
                isReloading = true;
                ammountOfAmmo++;
                Debug.Log(reticle.GetComponent<SpriteRenderer>().color);
                reticle.GetComponent<SpriteRenderer>().color = HexToColor("FF4614"); //redish orange
                GameManager.current.Reload(ammoAmmount: ammountOfAmmo, isReloading: isReloading);            
            }
        }
        if(Input.GetKeyDown(KeyCode.R)) //make this an upgrade later
        {
            reticle.GetComponent<SpriteRenderer>().color = HexToColor("FF4614"); //redish orange
            GameManager.current.Reload(isReloading: true);
        }
    }
    
}
