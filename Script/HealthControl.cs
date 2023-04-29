using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMaxHealth(float maxHealth){
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetHealth(float maxHealth){
        slider.value = maxHealth;
    }
}
