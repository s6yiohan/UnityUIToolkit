using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStats : MonoBehaviour
{

    public UIDocument hud;

    private StatusBarBase healthBar;
    private StatusBarBase manaBar;
    private StatusBarBase expBar;

    public int currentHealth = 100;
    public int maxHealth = 100;
    [Range(0,1)]
    public float healthPerc = 1;

    public int currentMana = 300;
    public int maxMana = 300;
    [Range(0,1)]
    public float manaPerc = 1;

    public int currentExp = 0;
    public int maxExp = 15000;
    [Range(0,1)]
    public float expPerc = 1;




    // Start is called before the first frame update
    void Start()
    {
        var root = hud.rootVisualElement;
        
        healthBar = root.Q<StatusBarBase>("HealthBar");
        healthBar.value = currentHealth/maxHealth;
        manaBar = root.Q<StatusBarBase>("ManaBar");
        manaBar.value = currentMana/maxMana;
        expBar = root.Q<StatusBarBase>("ExpBar");
        expBar.value = currentExp/maxExp;

    }

    // Update is called once per frame
    void Update()
    {
        int damage = Random.Range(1,20);

        if(Input.GetKeyDown(KeyCode.UpArrow)){
            Heal(damage);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)){
            TakeDamage(damage);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            CastSpell(damage * 10);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            GainExp(damage * 25);
        }


        if(currentMana != maxMana)
        {
            RegenMana();
        }
    }

    private void OnValidate() {
        if(healthBar != null){
            healthBar.value = healthPerc;
            currentHealth = (int)(healthPerc * maxHealth);
        }
    }

    public void TakeDamage(int val){
        currentHealth -= val;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthPerc = (float) currentHealth / maxHealth;
        healthBar.value = healthPerc;
    }

    public void Heal(int val){
        currentHealth += val;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthPerc = (float) currentHealth / maxHealth;
        healthBar.value = healthPerc;
    }

    private void CastSpell(int val){
        currentMana -= val;
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
        manaPerc = (float) currentMana / maxMana;
        manaBar.value = manaPerc;
    }

    private void RegenMana(){
        currentMana += 2;
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
        manaPerc = (float) currentMana / maxMana;
        manaBar.value = manaPerc;
    }
    
    private void GainExp(int val){
        currentExp += val;
        currentExp = Mathf.Clamp(currentExp, 0, maxExp);
        expPerc = (float) currentExp / maxExp;
        expBar.value = expPerc;
    }

}
