using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    [SerializeField] private GameObject meteorRef;
    [SerializeField] private Transform pos;
    [SerializeField] private int maxNumberObject;
    [SerializeField] private int max,min;

    private int currentNumberObject = 0;
    private GameObject spawnMeteor;

    void Start(){
        StartCoroutine(SpawnMeteors());
    }

    IEnumerator SpawnMeteors(){
        while(true && currentNumberObject < 100){
            yield return new WaitForSeconds(Random.Range(min, max));
            currentNumberObject = currentNumberObject +1;
            spawnMeteor = Instantiate(meteorRef);
            spawnMeteor.transform.position = pos.position;
        }   
    }
}
