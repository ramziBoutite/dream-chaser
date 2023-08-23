using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class damage : MonoBehaviour
{
    public UnityEvent<Vector2> damageEvent;
    Animator anim;
    private float _max_health=100;
    public float max_health
    {
        get { return _max_health; }
        set { _max_health = value; }
    }
    [SerializeField]
    private float _health = 100;
    public float health { get { return _health; } set { _health = value; if (_health <= 0f) { is_alive = false; } } }
    public bool is_hit { get { return anim.GetBool("is_hit"); } set { anim.SetBool("is_hit",value); } }
    [SerializeField] private bool _is_alive = true;
    private bool invincible;
    private float time;
    public float timer;

    
    public bool is_alive
    {
        get { return _is_alive; }
        set { _is_alive = value; anim.SetBool("is_alive",value); }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void hit(int damage, Vector2 knock_back)
    {
        if(is_alive && !invincible)
        {
            health = health - damage;
            invincible = true;
            damageEvent.Invoke(knock_back);
            Debug.Log("try invoke");
            event_class.char_damaged(gameObject, damage);
            is_hit = true;
        }
    }
    public bool heal(int heal_amount)
    {
        if(is_alive && health<100)
        {
            float healed_amount = Mathf.Max(0, max_health - health); 
            float actual_heal = Mathf.Min(healed_amount, heal_amount);
            health += actual_heal;
            event_class.char_healed.Invoke(gameObject, actual_heal);
            return true;
        }
        else return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(invincible)
        {
            if(time > timer )
            {
                invincible = false;
                    time = 0f;
            }
            time += Time.deltaTime;
        }
    }
}
