using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float currentHealth;
    [SerializeField] HealthControl healhBar;
    [SerializeField] Animator healthEffect;

    void Start(){
        currentHealth = maxHealth;
        healhBar.SetMaxHealth(maxHealth);
    }
    void Update(){
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
    }
}
