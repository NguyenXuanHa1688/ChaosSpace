using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    [SerializeField] private GameObject meteorRef;
    [SerializeField] private Transform pos;

    private int maxNumber = 0;
    private GameObject spawnMeteor;

    void Start(){
        StartCoroutine(SpawnMeteors());
    }

    IEnumerator SpawnMeteors(){
        while(true && maxNumber < 100){
            yield return new WaitForSeconds(Random.Range(5, 20));
            maxNumber = maxNumber +1;
            spawnMeteor = Instantiate(meteorRef);
            spawnMeteor.transform.position = pos.position;
        }   
    }
}
