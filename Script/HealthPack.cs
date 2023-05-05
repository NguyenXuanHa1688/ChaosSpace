using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] GameObject healthSpawnPoint;
    [SerializeField] int currentHealth;
    [SerializeField] Animator heathPack;

    private string BULLET_TAG = "Bullet";
    private string EARTH_TAG = "Earth";
    private void Update(){
        Chase();
    }

    private void Chase(){
        transform.position = Vector2.MoveTowards(transform.position, healthSpawnPoint.transform.position, speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(BULLET_TAG)){
            heathPack.SetTrigger("Impact");
            Invoke("DestroyHealth",1f);      
        } 
        if(collision.gameObject.CompareTag(EARTH_TAG)){
            heathPack.SetTrigger("Impact");
            Invoke("DestroyHealth",1f);         
        } 
    }

    void DestroyHealth(){
        Destroy(gameObject); 
    }
}
