using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public int maxHealth = 3; // Max ilosc serc

    // Canvas i ikony serc
    // smierc gracza
    // serca do zbierania

    [SerializeField] List<Image> hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    void Start()
    {

    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            TakeDamage(1); // strac serce
        }

        if (collision.CompareTag("Heal"))
        {
            Heal(1); // dodaj serce
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage; // health = health - damage;
        UpdateHearts();
        if (health <= 0) Debug.Log("Przegrales!");
    }

    public void Heal(int amount)
    {
        health += amount; // health = health + amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHearts();
    }

    void UpdateHearts()
    {
        int healthNow=health;
        foreach (var heart in hearts) 
        {
            if(healthNow > 0)
            {
                healthNow--;
                heart.sprite = fullHeart;
            }
            else
            {
                heart.sprite = emptyHeart;
            }
        }
    }
}
