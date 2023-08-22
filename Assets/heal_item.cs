using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal_item : MonoBehaviour
{
    public int heal_amount = 5;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        damage _damage = collision.gameObject.GetComponent<damage>();
        if(_damage)
        {
            _damage.heal(heal_amount);
            Destroy(gameObject);
        }
    }

}
