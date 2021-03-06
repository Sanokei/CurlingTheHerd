using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Kinematics and stuff
*/
public class MovementScript : MonoBehaviour
{
    [SerializeField]
    private Vector2 _avgVelocity;
    [SerializeField]
    private Vector2 _max_avgVelocity;
    [SerializeField]
    private float _floatiness = 0.4f; //smoll num uwu = more floaty
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        /*Raw gets rid of the smoothing (compared to GetAxis which feels floaty)*/
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        if(DialogManager.GetInstance().dialogIsPlaying || GoalManager.Dead){
            inputX = 0;
            inputY = 0;
        }

        _rb.AddForce(
            new Vector2(
                Mathf.Clamp((inputX == 0 ? -_rb.velocity.normalized.x * _floatiness : inputX * _avgVelocity.x),- _max_avgVelocity.x, _max_avgVelocity.x), 
                Mathf.Clamp((inputY == 0 ? -_rb.velocity.normalized.y * _floatiness: inputY * _avgVelocity.y), - _max_avgVelocity.y, _max_avgVelocity.y)
            )
        , ForceMode2D.Impulse);
    }
}