using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    [SerializeField] private GameObject alienRef;
    [SerializeField] private Transform pos;
    [SerializeField] private int min, max;
    [SerializeField] int maxNumberObject;
    private int currentNumberObject = 0;
    private GameObject spawnMeteor;

    void Start(){
        StartCoroutine(SpawnMeteors());
    }

    IEnumerator SpawnMeteors(){
        while(true && currentNumberObject < maxNumberObject){
            yield return new WaitForSeconds(Random.Range(min, max));
            currentNumberObject = currentNumberObject +1;
            spawnMeteor = Instantiate(alienRef);
            spawnMeteor.transform.position = pos.position;
        }   
    }
}
