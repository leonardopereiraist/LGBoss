using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] HSB HSB;
    public float maxHp, maxStam, damageTest, spendTest;
    private float hp, stam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        (hp, stam) = (maxHp, maxStam);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    [ContextMenu("Test Spend")]
    public void TestSpend()
    {
        spendStamina(spendTest);
    }

        public void spendStamina(float spend)
    {
        stam -= spend;
        HSB.setStam(stam/maxStam);
    }
}
