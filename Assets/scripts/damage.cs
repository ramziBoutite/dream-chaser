using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
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
    public void hit(int damage)
    {
        if(is_alive && !invincible)
        {
            health = health - damage;
            invincible = true;
        }
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
        hit(10);
    }
}
