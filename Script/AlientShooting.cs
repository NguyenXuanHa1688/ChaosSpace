using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlientShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletRef;
    [SerializeField] private Transform pos;

    private int maxNumber = 0;
    private GameObject bullet;

    void Start(){
        StartCoroutine(SpawnBullet());
    }

    IEnumerator SpawnBullet(){
        while(true && maxNumber < 100){
            yield return new WaitForSeconds(1);
            maxNumber = maxNumber +1;
            bullet = Instantiate(bulletRef);
            bullet.transform.position = pos.position;
        }   
    }
}
