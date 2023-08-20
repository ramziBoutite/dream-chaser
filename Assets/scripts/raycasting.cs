using System.Collections;
using UnityEngine;

namespace Assets.scripts
{
    public class raycasting : MonoBehaviour
    {
        public ContactFilter2D contactFilter;
        public float raycastRange= 1f;
        public float wallCheckRange = 2f;
        public bool isgnd,isonwall,isonceiling;
        RaycastHit2D[] results = new RaycastHit2D[2];
        RaycastHit2D[] wallHits = new RaycastHit2D[2];
        RaycastHit2D[] ceilingHits = new RaycastHit2D[2];
        Vector2 wallCheck => transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        Animator anim;
        Rigidbody2D rb;
        CapsuleCollider2D coll;
        private void Awake()
        {
          coll = GetComponent<CapsuleCollider2D>();
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            isgnd = coll.Raycast(Vector2.down, contactFilter, results, raycastRange) > 0;
            anim.SetBool("isgnd", isgnd);
            isonwall = coll.Raycast(wallCheck, contactFilter, wallHits, wallCheckRange) > 0;
            anim.SetBool("isonwall", isonwall);
            isonceiling = coll.Raycast(Vector2.up, contactFilter, ceilingHits, raycastRange) > 0;
            anim.SetBool("isonceiling", isonceiling);
        }
    }
}