using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] GameObject earth;
    [SerializeField] private float rotateSpeed;

    private string PLAYER_TAG = "Player";
    private string EARTH_TAG = "Earth";
    private string BULLET_TAG = "Bullet";
    private string EXPLOSION_TAG = "Boom";
    private Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
    }

    private void Update(){
        transform.Rotate(0,0,rotateSpeed);
        Chase();
    }

    private void Chase(){
        transform.position = Vector2.MoveTowards(transform.position, earth.transform.position, speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(PLAYER_TAG)){
            animator.SetTrigger(EXPLOSION_TAG);
            Invoke("Disapear", 0.42f);
        } 
        if(collision.gameObject.CompareTag(EARTH_TAG)){
            animator.SetTrigger(EXPLOSION_TAG);
            Invoke("Disapear", 0.42f);
        } 
        if(collision.gameObject.CompareTag(BULLET_TAG)){
            animator.SetTrigger(EXPLOSION_TAG);
            Invoke("Disapear", 0.42f);
        } 
    }

    void Disapear(){
        Destroy(gameObject);
    }
}
