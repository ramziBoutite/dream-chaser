using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public Vector2 knock_back;

    public int attack_damage = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        damage _damage = collision.GetComponent<damage>();
        if(_damage != null)
        {
            _damage.hit(attack_damage, knock_back);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
