using UnityEngine;

public class HSB : MonoBehaviour
{
    private RectTransform hpBar, stamBar;
    private float maxHp, maxStam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hpBar = transform.GetChild(0).GetComponent<RectTransform>();
        maxHp = hpBar.rect.width;
        stamBar = transform.GetChild(1).GetComponent<RectTransform>();
        maxStam = stamBar.rect.width;
    }

    // Update is called once per frame
    public void setHp(float hpRatio)
    {
        float newWid = hpRatio * maxHp;
        hpBar.sizeDelta = new Vector2(newWid, hpBar.rect.height);
    }
        public void setStam(float stamRatio)
    {
        float newWid = stamRatio * maxStam;
        stamBar.sizeDelta = new Vector2(newWid, stamBar.rect.height);
    }   

}
