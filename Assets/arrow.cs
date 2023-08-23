using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public Vector2 arrowSpeed = new Vector2(3,0);
    public int damage;
    Rigidbody2D rb;
    public Vector2 knock_back;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(arrowSpeed.x * transform.localScale.x, arrowSpeed.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        damage _damage = collision.GetComponent<damage>();
        if (_damage != null)
        {
            _damage.hit(damage, knock_back);
            Debug.Log("hit called");
            Destroy(gameObject);
        }
    }
}
