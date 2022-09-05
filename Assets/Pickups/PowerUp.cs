using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] PowerUpEffect powerUpEffect;

       private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Power up collidina");
        if (collision.gameObject.tag != "Player") { return; }
        
        Destroy(gameObject);
        powerUpEffect.Apply(collision.gameObject);

    }

}
