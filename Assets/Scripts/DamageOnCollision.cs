using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageOnCollision : MonoBehaviour
{
    public List<string> Targets;
    public bool DestroyOnContact;

    public DamageAbility Damage;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (Targets.Contains(collider.gameObject.tag))
        {
            var dps = collider.gameObject.AddComponent<DamageAbility>();

            dps.DamageDealt = Damage.DamageDealt;
            dps.Delay = Damage.Delay;
            dps.DamageOverTime = Damage.DamageOverTime;
            if (dps.DamageOverTime)
            {
                dps.ApplyEveryNSeconds = Damage.ApplyEveryNSeconds;
                dps.Interval = Damage.Interval;
            }
        }

        if (DestroyOnContact)
        {
            Destroy(gameObject);
        }
    }
}

