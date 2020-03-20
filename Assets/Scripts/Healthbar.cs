using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Text))]
public class Healthbar : MonoBehaviour
{
    public Slider Slider;
    public BaseStats BaseStats;
    public Health Health;
    public Text HealthDisplay;

    public void SetMaxHealth(float health)
    {
        Slider.maxValue = health;
    }

    public void SetHealth(float health)
    {
        Slider.value = health;
    }

    void Start()
    {
        SetMaxHealth((BaseStats.BaseHealth));
        Slider.value = Health.CurrentHealth;
        UpdateDisplayText();
    }

    void OnEnable()
    {
        Health.OnHealthChanged.AddListener(OnHealthChanged);
    }

    void OnDisable()
    {
        Health.OnHealthChanged.RemoveListener(OnHealthChanged);
    }

    private void UpdateDisplayText()
    {
        HealthDisplay.text = $"{Health.CurrentHealth}/{BaseStats.BaseHealth}";
    }

    public void OnHealthChanged()
    {
        SetHealth(Health.CurrentHealth);
        UpdateDisplayText();
    }

}
