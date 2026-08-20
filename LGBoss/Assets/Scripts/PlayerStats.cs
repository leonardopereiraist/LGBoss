using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] HSB HSB;
    public float maxHp, maxStam, damageTest, spendTest, hp, stam, stamRegen;
    private float regenTimer = 0f;
    [SerializeField] private float regenDelay = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        (hp, stam) = (maxHp, maxStam);
    }

    // Update is called once per frame
    void Update()
    {
        if (regenTimer > 0)
        {
            regenTimer -= Time.deltaTime;
        }
        else if (stam < maxStam)
        {
            stam += stamRegen * Time.deltaTime;
            HSB.setStam(stam/maxStam);

        }
    }

    public bool SpendStamina(float amount)
    {  
        if (stam >= amount)
        {
            stam -= amount;
            regenTimer = regenDelay;
            HSB.setStam(stam/maxStam);
            return true;
        }
        return false;
    }    
    
    #region Cheats
    [ContextMenu("Heal")]
    public void Heal()
    {
        hp = maxHp;
        HSB.setHp(1);

    }
    [ContextMenu("Test Damage")]
    public void TestDamage()
    {
        dealDamage(damageTest);
    }
    
    public void dealDamage(float damage)
    {
        hp -= damage;
        HSB.setHp(hp/maxHp);
    }

    [ContextMenu("Rest")]
    public void Rest()
    {
        stam = maxStam;
        HSB.setStam(1);

    }
    #endregion
}
