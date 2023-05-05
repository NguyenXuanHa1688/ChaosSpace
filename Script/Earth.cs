using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earth : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float currentHealth;
    [SerializeField] HealthControl healhBar;
    [SerializeField] private GameObject buttletPrefab;
    [SerializeField] Animator healthEffect;

    private string METEOR_TAG = "Meteor";
    private string HEALTH_TAG = "Hp";
    private string ALIEN_BULLET = "AlienBullet";
    private string ALIEN_TAG = "Alien";

    void Start(){
        currentHealth = maxHealth;
        healhBar.SetMaxHealth(maxHealth);
    }

    void Update(){
        if(currentHealth < 100f){ 
            HealthRegen();
        }
        if(currentHealth < 80f && currentHealth > 50f){ 
            healthEffect.SetTrigger("HealthFull");
        }
        if(currentHealth < 50f && currentHealth > 20f){ 
            healthEffect.SetTrigger("HealthMedium");
        }
        if(currentHealth < 20f && currentHealth > 0f){ 
            healthEffect.SetTrigger("HealthLow");
        }
        if(currentHealth < 0f){ 
            healthEffect.SetTrigger("NoHealth");
        }
        healthEffect.SetTrigger("HealthDone");
        if(Input.GetKey(KeyCode.DownArrow)){
            TakeDamage(30f);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            EatHealth();
        }
    }

    void TakeDamage(float damage){
        currentHealth -= damage * Time.deltaTime;
        healhBar.SetHealth(currentHealth);
        Debug.Log(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(METEOR_TAG)){
            TakeDamage(10f);
        } 
        if(collision.gameObject.CompareTag(HEALTH_TAG) && currentHealth < 100f){
            EatHealth();
            healthEffect.SetTrigger("Heal");
        }
        if(collision.gameObject.CompareTag(ALIEN_BULLET)){
            TakeDamage(5f);
        }  
        if(collision.gameObject.CompareTag(ALIEN_TAG)){
            TakeDamage(40f);
        } 
    }

    void EatHealth(){
        currentHealth += 10f * Time.deltaTime;
        healhBar.SetHealth(currentHealth);
        Debug.Log(currentHealth);
    }

    void HealthRegen(){
        currentHealth += 2f * Time.deltaTime;
        healhBar.SetHealth(currentHealth);
        Debug.Log(currentHealth);
    }

}
