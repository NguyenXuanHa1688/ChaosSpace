using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] moveSpots;
    [SerializeField] private float startWaitTime;
    [SerializeField] private Animator alienAnimator;

    private int randomSpot;
    private float waitTime;
    private string BULLET_TAG = "Bullet";
    private string PLAYER_TAG = "Player";
    private string EARTH_TAG = "Earth";
    private string ALIEN_TAG = "Alien";

    void Start(){
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update(){
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f){
            if(waitTime <= 0){
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime; 
            } else{
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(BULLET_TAG)){
            alienAnimator.SetTrigger("Explode");
            Invoke("Disapear", 1f);
        } 
        if(collision.gameObject.CompareTag(PLAYER_TAG)){
            alienAnimator.SetTrigger("Explode");
            Invoke("Disapear", 1f);
        } 
        if(collision.gameObject.CompareTag(EARTH_TAG)){
            alienAnimator.SetTrigger("Explode");
            Invoke("Disapear", 1f);
        } 
        if(collision.gameObject.CompareTag(ALIEN_TAG)){
            alienAnimator.SetTrigger("Explode");
            Invoke("Disapear", 1f);
        }
    }

    void Disapear(){
        Destroy(gameObject);
    }   
}
