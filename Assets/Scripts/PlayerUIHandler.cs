using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHandler : MonoBehaviour
{
    // Player stat variables
    public float maxHealth = 100f;
    public float currentHealth;

    public float maxHunger = 100f;
    public float currentHunger;
    public float hungerDecreaseRate = 0.5f;

    public float maxThirst = 100f;
    public float currentThirst;
    public float thirstDecreaseRate = 1f;

    public Slider healthSlider;
    public Slider hungerSlider;
    public Slider thirstSlider;

    private void Start()
    {
        // Initialize stats
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentThirst = maxThirst;

        // Initialize UI sliders
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        hungerSlider.maxValue = maxHunger;
        hungerSlider.value = currentHunger;

        thirstSlider.maxValue = maxThirst;
        thirstSlider.value = currentThirst;
    }

    private void Update()
    {
        // Decrease hunger and thirst over time
        currentHunger -= hungerDecreaseRate * Time.deltaTime;
        currentThirst -= thirstDecreaseRate * Time.deltaTime;

        // Update UI sliders
        hungerSlider.value = currentHunger;
        thirstSlider.value = currentThirst;

        // Check if hunger or thirst reaches zero
        if (currentHunger <= 0)
        {
            currentHunger = 0;
            TakeDamage(10 * Time.deltaTime); // Take damage when starving
        }

        if (currentThirst <= 0)
        {
            currentThirst = 0;
            TakeDamage(15 * Time.deltaTime); // Take damage when dehydrated
        }

        // Update health UI slider
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);//player has died
        }
    }

    public void Eat(float amount)
    {
        currentHunger += amount;
        if (currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
        }
    }

    public void Drink(float amount)
    {
        currentThirst += amount;
        if (currentThirst > maxThirst)
        {
            currentThirst = maxThirst;
        }
    }
}