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
    GameObject _compareOldMap;

    // Start is called before the first frame update
    void Start()
    {
       
        currentMap = Instantiate(mapTilesList[Random.Range(0, mapTilesList.Length - 1)], mapParent);
        Surface2D.BuildNavMeshAsync();  // innitial buildas nav mesho
        _compareOldMap = currentMap;

    }

    public void GenerateMap()
    {

    Destroy(currentMap);  // pasalina mapa
   
        currentMap = Instantiate(mapTilesList[Random.Range(0, mapTilesList.Length - 1)], mapParent);  // mapas is array

    }

    private void Update()
    {
      if (currentMap != null &&  _compareOldMap != currentMap)
        {
            Debug.Log("Refreshinu NavMap");
            Surface2D.UpdateNavMesh(Surface2D.navMeshData);
            _compareOldMap = currentMap;
        }    
            



    }
}
