using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnter : MonoBehaviour
{
   
     private void OnTriggerEnter2D(Collider2D collision)
    {
        mapGenerator mapGen = GetComponentInParent<mapGenerator>();
        mapGen.GenerateMap();
    }
}
