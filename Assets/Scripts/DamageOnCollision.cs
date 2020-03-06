using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

    public class DamageOnCollision : MonoBehaviour
    {
        public float DamageDealt;
        public bool DestroyOnContact;

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                collider.gameObject.GetComponent<Health>().ReduceHealth(DamageDealt);
                if (DestroyOnContact)
                {
                    Destroy(gameObject);
                }
            }
        }
    }