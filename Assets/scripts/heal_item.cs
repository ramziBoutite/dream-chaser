using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal_item : MonoBehaviour
{
    public Vector3 spin = new Vector3(0, 180, 0);
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
            bool heal_done= _damage.heal(heal_amount);
            if(heal_done)
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.eulerAngles += spin * Time.deltaTime;
    }

}
