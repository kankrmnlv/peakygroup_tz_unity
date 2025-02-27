using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currHealth;

    public HealthbarUI healthbar;

    public DamageScreen damageScreen;

    private void Start()
    {
        currHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currHealth -= damage;
        healthbar.SetHealth(currHealth);
        if(currHealth > 0)
        {
            damageScreen.TriggerFlash();
        }
        else
        {
            GameManager.Instance.GameOver();
        }
    }
}
