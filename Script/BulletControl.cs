using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] private Animator bulletAnimator;
    
    private string ON_IMPACT = "Impact";
    private string METEOR_TAG = "Meteor";
    private string WALL_TAG = "Wall";

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(METEOR_TAG)){
            bulletAnimator.SetTrigger(ON_IMPACT);
            Invoke("DestroyObject", 0.42f); 
        }
        if(collision.gameObject.CompareTag(WALL_TAG)){
            DestroyObject(); 
        }
    }
 
    void DestroyObject(){ 
        Destroy(gameObject);
    }
}
