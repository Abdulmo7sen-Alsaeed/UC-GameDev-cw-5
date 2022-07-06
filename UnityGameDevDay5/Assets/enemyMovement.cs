using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    int direction;
    public GameObject rightTrigger;
    public GameObject leftTrigger;

    // Start is called before the first frame update
    void Start()
    {
        //Physics2D.IgnoreLayerCollision(7, 8, true);
        rb = GetComponent<Rigidbody2D>();
        direction = 1;
        //Physics2D.BoxCast()
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "below")
            Destroy(gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right*direction*2.5f;
        if (direction > 0)
        {
            Collider2D check= Physics2D.OverlapBox(rightTrigger.transform.position, Vector2.one * 0.5f, 0f);
            if (check == null || check.tag != "ground")
                direction = -direction;
        }

        if (direction < 0)
        {
            Collider2D check = Physics2D.OverlapBox(leftTrigger.transform.position, Vector2.one * 0.5f, 0f);
            if (check == null || check.tag != "ground")
                direction = -direction;
        }
    }

    
}
