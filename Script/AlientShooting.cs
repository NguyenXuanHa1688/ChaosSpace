using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlientShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletRef;
    [SerializeField] private Transform pos;
    [SerializeField] private int maxNumberObject;

    private int currentNumberObject = 0;
    private GameObject bullet;

    void Start(){
        StartCoroutine(SpawnBullet());
    }

    IEnumerator SpawnBullet(){
        while(true && currentNumberObject < maxNumberObject){
            yield return new WaitForSeconds(1);
            currentNumberObject = currentNumberObject +1;
            bullet = Instantiate(bulletRef);
            bullet.transform.position = pos.position;
        }   
    }
}
