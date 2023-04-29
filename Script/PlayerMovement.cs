using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //[SerializeField] private Animator animator;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject buttletPrefab;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public Animator flashAnimator;
    
    private string SHOOT = "IsShoot";

    // private string MOVE_LEFT = "MoveLeft";
    // private string MOVE_RIGHT = "MoveRight";
    Vector2 mousePos;

    private void Update()
    {
        // if(Input.GetKey(KeyCode.A)){
        //     gameObject.transform.Rotate(0f, 0f, 30f * Time.deltaTime * 10f); 
        //     animator.SetBool(MOVE_LEFT, true);        
        // } else{
        //     animator.SetBool(MOVE_LEFT, false);     
        // }
        // if(Input.GetKey(KeyCode.D)){
        //     gameObject.transform.Rotate(0f, 0f, -30f * Time.deltaTime * 10f);
        //     animator.SetBool(MOVE_RIGHT, true); 
        // } else {
        //     animator.SetBool(MOVE_RIGHT, false); 
        // }
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        } else{
            flashAnimator.SetBool(SHOOT,false);
        } 
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void Shoot(){
        GameObject bullet = Instantiate(buttletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shootPoint.up * bulletForce, ForceMode2D.Impulse);
        flashAnimator.SetBool(SHOOT,true);
    }
}
