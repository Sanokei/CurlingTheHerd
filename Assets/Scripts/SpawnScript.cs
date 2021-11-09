using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    GameObject bullet;
    float randX, randY;
    Vector2 whereToSpawn;
    public float spawnRate = 0.5f;
    float nextSpawn = 0.0f;
    float screenWidth;
    float screenHeight;
    float offScreenOffset = 10f;
    float bulletSpeed = 3.5f;
    
    void Start()
    {
        //get camera width and height
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect + offScreenOffset;
        screenHeight = Camera.main.orthographicSize + offScreenOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            //get random outside of window bounds
            randX = Random.Range(-Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * Camera.main.aspect);
            randY = Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize);
            whereToSpawn = Random.Range(0, 2) == 0 ? Random.Range(0, 2) == 0 ? new Vector2(screenWidth, randY) : new Vector2(screenWidth, randY) : Random.Range(0, 2) == 0 ? new Vector2(randX, screenHeight) : new Vector2(randX, screenHeight);
            //Quaternion.identity = no rotation
            GameObject bullet = Instantiate(Resources.Load("Bullet"), (Vector2) whereToSpawn, transform.rotation) as GameObject;
            Vector2 direction = (Vector2)(new Vector2(0,0) - (Vector2)bullet.transform.position);
            bullet.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed,ForceMode2D.Impulse);
        }
    }
}
