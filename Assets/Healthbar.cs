using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider health_slider;
    public TMP_Text healthbar_text;
    damage player_damage;
    private void Awake()
    {
        health_slider = GetComponent<Slider>();
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        player_damage = playerGO.GetComponent<damage>();
    }
    // Start is called before the first frame update
    void Start()
    {

        health_slider.value = CalculateSliderPercentage(player_damage.health,player_damage.max_health);
        healthbar_text.text = player_damage.health.ToString();
    }
    private void OnEnable()
    {
        player_damage.damage_for_health_bar.AddListener(onhealthchange);
    }
    private void OnDisable()
    {
        player_damage.damage_for_health_bar.RemoveListener(onhealthchange);
    }
    private void onhealthchange(float health,float maxHealth)
    {
        health_slider.value = CalculateSliderPercentage(player_damage.health, player_damage.max_health);
        healthbar_text.text = player_damage.health.ToString();
    }
    private float CalculateSliderPercentage( float health, float max_health)
    {
        return health / max_health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
