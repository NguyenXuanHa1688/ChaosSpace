using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealt : MonoBehaviour
{
    [SerializeField] private GameObject healthRef;
    [SerializeField] private Transform pos;
    [SerializeField] private int minRan, maxRan;

    private int maxNumber = 0;
    private GameObject spawnHealth;

    void Start(){
        StartCoroutine(SpawnHealthPack());
    }

    IEnumerator SpawnHealthPack(){
        while(true && maxNumber < 100){
            yield return new WaitForSeconds(Random.Range(minRan, maxRan));
            maxNumber = maxNumber +1;
            spawnHealth = Instantiate(healthRef);
            spawnHealth.transform.position = pos.position;
        }   
    }
}
