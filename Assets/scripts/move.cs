using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using Assets.scripts;
using Newtonsoft.Json.Linq;

public class move : MonoBehaviour
{
    private bool _ismoving = false;
    private bool _isrunning;
    private damage _damage;
    private Rigidbody2D rb;
    public float walkSpeed = 7f,speed,runspeed = 10.5f,airspeed = 5f, attack_speed =2f;
    Vector2 moveInp;
    Animator animator;
    raycasting raycasting;
    public float jump;
    public bool can_input =true,inputed=false;
    public static move instance;

    public bool ismoving { get
        {
            return _ismoving; 
        } private set
        {
            _ismoving = value;
            animator.SetBool("walk", value );
        } }
    public bool isrunning { get
        {
            return _isrunning;
        }
        set
        {
            _isrunning = value;
        }
    }
    
    private void Awake()
    {
        instance = this; 
        _damage = GetComponent<damage>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        raycasting = GetComponent<raycasting>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        // basic move
        if(!_damage.is_hit)
        {
            if (raycasting.isgnd && animator.GetBool("canmove"))
            { rb.velocity = new Vector2(moveInp.x * speed, rb.velocity.y); }
            else if (!raycasting.isgnd && !raycasting.isonwall)
            { rb.velocity = new Vector2(moveInp.x * speed, rb.velocity.y); }
            else if (!animator.GetBool("canmove"))
            { rb.velocity = Vector2.zero; }
            else { rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y); }
        }
        
        //move speed
        if (raycasting.isgnd)
        {
            if (ismoving && !animator.GetBool("gnd_attack") && !animator.GetBool("bow"))
            {
                if (isrunning )
                {
                    animator.SetBool("run", true);
                    speed = runspeed;
                }
                else 
                {
                    animator.SetBool("run", false);
                    speed = walkSpeed;
                }
            }

            else if (animator.GetBool("gnd_attack") ) { speed = attack_speed; }
            else if (animator.GetBool("combo")) { speed = attack_speed; }
            else
            {
                animator.SetBool("run", false);
                speed = 0f;
            }
        }
        else { speed = airspeed; }


        //flip
        if (rb.velocity.x == 0f) { }
        else if (moveInp.x < Mathf.Epsilon)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInp.x > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        //rise fall anim
        animator.SetFloat("yvelocity", rb.velocity.y);
       // Debug.Log(rb.velocity.x);
    }
    public void onMove(InputAction.CallbackContext context)
    {

        moveInp = context.ReadValue<Vector2>();
        ismoving = moveInp != Vector2.zero;
       if (context.canceled)
        {
            animator.SetBool("run", false);
            speed = 0f;
        }
    }
    public void onRon (InputAction.CallbackContext context)
    {
        if (context.started && ismoving && raycasting.isgnd && animator.GetBool("canmove"))
        {
            isrunning = true;
        }
        else if (context.canceled)
        {
            isrunning = false;
            animator.SetBool("run", false);
        }
    }
    public void onjump(InputAction.CallbackContext context)
    {
        if(context.started && raycasting.isgnd && animator.GetBool("canmove"))
        {
            rb.velocity =new Vector2(rb.velocity.x,jump);
            animator.SetTrigger("jump");
        }
    }
    public void onattack (InputAction.CallbackContext context)
    {
        if  (context.started && raycasting.isgnd)
        {
            if (can_input)
            {
                inputed = true;
                can_input = false;
                animator.SetTrigger("gnd_attack");
            }
        }
        else if(context.canceled){
            can_input = true; inputed=false;
        }
        
    }
    public void input_manager()
    {
        can_input = !can_input;
    }
    public void onhit(Vector2 knockback)
    {
        Debug.Log("invoked");
        rb.velocity = new Vector2 (rb.velocity.x +knockback.x * transform.localScale.x * -1 , rb.velocity.y+knockback.y+1);
    }
    public void onbow(InputAction.CallbackContext context)
    {
        if (context.started && raycasting.isgnd)
        {
            
                
                animator.SetTrigger("bow");
            
        }
 

    }
}
