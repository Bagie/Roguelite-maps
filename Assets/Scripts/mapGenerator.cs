using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mapGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] mapTilesList;
    [SerializeField] Transform playerPosition;
    [SerializeField] NavMeshSurface2d Surface2D;
    GameObject currentMap = null;
    [SerializeField] Transform mapParent; 
    
    // Start is called before the first frame update
    void Start()
    {
       currentMap = Instantiate(mapTilesList[Random.Range(0, mapTilesList.Length - 1)], mapParent);
        Surface2D.GetComponent<NavMeshSurface2d>().BuildNavMeshAsync();

    }

    public void GenerateMap()
    {
/*        foreach (Transform child in this.currentMap.transform)
            GameObject.Destroy(child.gameObject);*/

        
        //Debug.Log(currentMap.gameObject.name);
           //DestroyImmediate(this.currentMap.gameObject, true);
           Destroy(currentMap);



        currentMap = Instantiate(mapTilesList[Random.Range(0, mapTilesList.Length - 1)], mapParent);
        Surface2D.GetComponent<NavMeshSurface2d>().BuildNavMeshAsync();
        // Instantiate(mapTilesList[Random.Range(0, mapTilesList.Length-1)]);
    }
  
}
