using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Exp gems")]

public class ExpGem : PowerUpEffect
{
    [SerializeField] public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerLevel>().GainExperience(amount);
    }

}
