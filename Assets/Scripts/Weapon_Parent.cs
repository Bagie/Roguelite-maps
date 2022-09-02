using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Parent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }

    private void Update()
    {
        transform.right = (PointerPosition-(Vector2)transform.position).normalized ;
       
    }

    public void AttackAllWeapons()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<wpn_blast>().Attack();  //reiktu suvienodinti, kad nekviestu specifinio, o visus
        }
    }
}
