using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public enum ConsumableType { Food, Water }
    public ConsumableType type;
    public float amount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerUIHandler playerStats = other.GetComponent<PlayerUIHandler>();
            if (playerStats != null)
            {
                if (type == ConsumableType.Food)
                {
                    playerStats.Eat(20);
                }
                else if (type == ConsumableType.Water)
                {
                    playerStats.Drink(10);
                }
                Destroy(gameObject);
            }
        }
    }
}