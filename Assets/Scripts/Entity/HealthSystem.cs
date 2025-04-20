using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int _maxHealth;
    private int _crtHealth;
    
    public System.Action<int> OnHealthChange;
    public System.Action OnDeath;

    public void Initialize(int health)
    {
        _maxHealth = health;
        _crtHealth = health;
    }

    public void ResetHealth()
    {
        _crtHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _crtHealth -= damage;
        OnHealthChange?.Invoke(_crtHealth);
        if (_crtHealth <= 0)
        {
            EntityDeath();
        }
    }

    private void EntityDeath()
    {
        OnDeath?.Invoke();
    }
}
