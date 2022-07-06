using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jump;
    public bool canJump = true;
    public Animator anom;
    public SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        jump = 20;
        rb = GetComponent<Rigidbody2D>();
        anom = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        { canJump = true;
        anom.SetBool("jump", false);}
        else if (collision.gameObject.tag == "enemy")
            Destroy(gameObject);


    }
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="enemy")
            Destroy(gameObject);


    }*/
    // Update is called once per frame
    void Update()
    {
        

        Vector2 temp = rb.velocity;
        if (Input.GetAxis("Horizontal") > 0)
            sprite.flipX = false;
        if (Input.GetAxis("Horizontal") < 0)
            sprite.flipX = true;

        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
                                                                        //print(canJump);
            temp.y = jump;
            canJump = false;
            anom.SetBool("jump", true);
        }

        temp.x = Input.GetAxis("Horizontal")*speed;
        rb.velocity = temp;
    }

}
