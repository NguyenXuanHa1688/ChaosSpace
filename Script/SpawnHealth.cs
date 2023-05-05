using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealt : MonoBehaviour
{
    [SerializeField] private GameObject healthRef;
    [SerializeField] private Transform pos;
    [SerializeField] private int minRan, maxRan;
    [SerializeField] private int maxNumberObject;

    private int currentNumberObject = 0;
    private GameObject spawnHealth;

    void Start(){
        StartCoroutine(SpawnHealthPack());
    }

    IEnumerator SpawnHealthPack(){
        while(true && currentNumberObject < maxNumberObject){
            yield return new WaitForSeconds(Random.Range(minRan, maxRan));
            currentNumberObject = currentNumberObject +1;
            spawnHealth = Instantiate(healthRef);
            spawnHealth.transform.position = pos.position;
        }   
    }
}
