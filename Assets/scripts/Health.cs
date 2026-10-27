using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float invulnerableTime = 1f;
    public Slider healthBar;
    public GameManager manager;

    float cooldown = 0f;
    bool dead = false;

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
        }
        UpdateBar();
    }

    void Update()
    {
        if (cooldown > 0f)
        {
            cooldown = cooldown - Time.deltaTime;
        }
    }

    public void TakeDamage(int amount)
    {
        if (dead || cooldown > 0f)
        {
            return;
        }
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        cooldown = invulnerableTime;
        UpdateBar();

        if (currentHealth == 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (dead)
        {
            return;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UpdateBar();
    }

    void Die()
    {
        dead = true;
        Debug.Log("Player died");
        if (manager != null)
        {
            manager.EndGame("GAME OVER");
        }
    }

    void UpdateBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
    }
}
