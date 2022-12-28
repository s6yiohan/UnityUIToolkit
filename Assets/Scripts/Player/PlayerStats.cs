using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStats : MonoBehaviour
{

    public UIDocument hud;

    private StatusBarBase healthBar;
    private StatusBarBase manaBar;

    public int currentHealth = 100;
    public int maxHealth = 100;

    [Range(0,1)]
    public float healthPerc = 1;
    // Start is called before the first frame update
    void Start()
    {
        var root = hud.rootVisualElement;
        healthBar = root.Q<StatusBarBase>("HealthBar");
        healthBar.value = currentHealth/maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate() {
        if(healthBar != null){
            healthBar.value = healthPerc;
            currentHealth = (int)(healthPerc * maxHealth);
        }
    }
}
