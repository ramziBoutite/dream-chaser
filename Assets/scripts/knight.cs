using Assets.scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class knight : MonoBehaviour
{
    Animator anim;
    public float speed;
    Rigidbody2D rb;
    raycasting raycasting;
    public detection_zone zone;
    bool _has_target;
    public bool has_target { get { return _has_target; } set { _has_target = value; anim.SetBool("has_target",value); } }
    public bool canmove { get { return anim.GetBool("canmove"); }  }

    public enum dir { left, right };
    private dir _dir;
    Vector2 dir_vector = Vector2.right;
    public dir knight_dir 
    { get 
        {
            return _dir; 
        }
     set
        {
            if( _dir != value)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * (-1), 1, 1);
                if (value == dir.right)
                {
                    dir_vector = Vector2.left;
                }
                else if (value == dir.left)
                {
                    dir_vector = Vector2.right;
                }
            }
            _dir = value;
        } 
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        raycasting = GetComponent<raycasting>(); 
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if(raycasting.isonwall && raycasting.isgnd)
        {
            Flip();
        }
        if (canmove)
        {
            rb.velocity = new Vector2(dir_vector.x * speed, rb.velocity.y);
        }
        else {
            rb.velocity = new Vector2(Mathf.Epsilon,rb.velocity.y);
        }
    }

    private void Flip()
    {
       if( knight_dir == dir.left)
        { knight_dir = dir.right; }
       else if(knight_dir == dir.right)
        { knight_dir = dir.left; }
    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        has_target = zone.colliders.Count > 0;
    }
}
