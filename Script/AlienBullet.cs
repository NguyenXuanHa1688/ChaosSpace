using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] GameObject Earth;

    private string BULLET_TAG = "Bullet";
    private string EARTH_TAG = "Earth";

    private void Update(){
        Chase();
    }

    private void Chase(){
        transform.position = Vector2.MoveTowards(transform.position, Earth.transform.position, speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(EARTH_TAG)){   
            DestroyObject();     
        } 
    }

    void DestroyObject(){
        Destroy(gameObject); 
    }
}
