using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] monsterPrefabs;
    [SerializeField] int monstersToSpawn = 1;
    [SerializeField] float spawnRadius = 1f;
    //[SerializeField] int monstersSpawn = 1;
    [SerializeField] float delayToSpawn = 0.1f;
    Vector3 centerOfSpawn;

    private void Awake()
    {
        centerOfSpawn = transform.position;
    }
    void Start()
    {
       
            StartCoroutine(SpanwMonster());
        
        
    }

    private IEnumerator SpanwMonster()
    {
        for (int i = 0; i < monstersToSpawn; i++)
        {
            if (monsterPrefabs != null)
            {
                Vector3 pos = RandomCircle(centerOfSpawn, spawnRadius);
                Instantiate(monsterPrefabs[0], pos, Quaternion.identity);
                yield return new WaitForSeconds(delayToSpawn);
            }
        }

    }



     
    

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = UnityEngine.Random.Range(1,50) * 360/monstersToSpawn;
        Vector3 pos;
        pos.x = center.x + radius + Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius + Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
 
 


