using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] private Animator bulletAnimator;
    
    private string ON_IMPACT = "Impact";
    private string METEOR_TAG = "Meteor";
    private string WALL_TAG = "Wall";

    void Update(){

    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(METEOR_TAG)){
            bulletAnimator.SetTrigger(ON_IMPACT);
            Invoke("Disapear", 0.42f); 
        }
        if(collision.gameObject.CompareTag(WALL_TAG)){
            Disapear(); 
        }
    }
 
    void Disapear(){ 
        Destroy(gameObject);
    }
}
