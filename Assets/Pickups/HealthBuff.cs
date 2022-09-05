using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Health buffs")]
public class HealthBuff : PowerUpEffect
{
    [SerializeField] public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<CharacterController>().HealthAdjustment(amount);
    }


}
