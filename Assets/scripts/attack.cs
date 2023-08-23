using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public Vector2 knock_back;

    public int attack_damage = 10;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 deliveredknock = transform.localScale.x > 0 ? knock_back : new Vector2(knock_back.x, knock_back.y);
        damage _damage = collision.GetComponent<damage>();
        if(_damage != null)
        {
            _damage.hit(attack_damage,knock_back);
            Debug.Log("hit called");
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
