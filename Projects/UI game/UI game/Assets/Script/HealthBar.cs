using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    private RectTransform Bar;
    private Image barImage;
    public UnityEvent Ontrigger;
    // Start is called before the first frame update
    void Start()
    {
        Health.totalHealth = 1f;
        Bar = GetComponent<RectTransform>();
        SetSize(Health.totalHealth);
        barImage = GetComponent<Image>();
    }

    public void Damage(float damage)
    {
        if ((Health.totalHealth -= damage) >= 0f)
        {
            Health.totalHealth -= damage;
        }
        else
        {
            Health.totalHealth = 0f;
            Ontrigger.Invoke();
        }


        if (Health.totalHealth < 0.3f)
        {
            barImage.color = Color.red;
        }

        SetSize(Health.totalHealth);
    }

    public void SetSize(float size)
    {
        Bar.localScale = new Vector3(size, 1f);
    }
}
    
