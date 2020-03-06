using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public Slider slider;
    public BaseStats baseStats;
    public Health health;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    void Start()
    {
        SetMaxHealth((baseStats.BaseHealth));
    }

    void OnEnable()
    {
        health.OnHealthChanged.AddListener(OnHealthChanged);
    }

    void OnDisable()
    {
        health.OnHealthChanged.RemoveListener(OnHealthChanged);
    }

    public void OnHealthChanged()
    {
        SetHealth(health.CurrentHealth);
    }

}
