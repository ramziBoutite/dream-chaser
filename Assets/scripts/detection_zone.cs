using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class detection_zone : MonoBehaviour
{
    public UnityEvent cliff_event;
    Collider2D Collider2D;
    public List<Collider2D> colliders = new List<Collider2D>();

    private void Awake()
    {
        Collider2D = GetComponent<Collider2D>(); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliders.Add(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        colliders.Remove(collision);    
        if(colliders.Count == 0)
        {
            cliff_event.Invoke();
        }
    }
}
