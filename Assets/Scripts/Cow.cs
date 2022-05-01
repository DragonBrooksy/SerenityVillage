using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    private int rand;
    private int count = 0;
    private float x, y;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float spriteHeight = transform.localScale.y * spriteRenderer.sprite.bounds.size.y;
        if (count == 0)
        {
            rand = Random.Range(0, 20);
            if (rand == 0)
            {
                x = 1;
                y = 0;
            }
            else if (rand == 1)
            {
                x = -1;
                y = 0;
            }
            else if (rand == 2)
            {
                x = 0;
                y = 1;
            }
            else if (rand == 3)
            {
                x = 0;
                y = -1;
            }
            else
            {
                x = 0;
                y = 0;
            }
            moveDelta = new Vector3(x, y, 0);
            animator.SetFloat("Horizontal", moveDelta.x);
            animator.SetFloat("Vertical", moveDelta.y);
            animator.SetFloat("Speed", moveDelta.sqrMagnitude);

            //Checks if there is something you can collide with vertically.
            hit = Physics2D.BoxCast(transform.position - new Vector3(0, spriteHeight / 2, 0), boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider == null)
            {
                //Move vertically.
                transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
            }

            //Checks if there is something you can collide with horizontally.
            hit = Physics2D.BoxCast(transform.position - new Vector3(0, spriteHeight / 2, 0), boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider == null)
            {
                //Move horizontally.
                transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
            }
            count += 1;
        }
        else
        {
            //Checks if there is something you can collide with vertically.
            hit = Physics2D.BoxCast(transform.position - new Vector3(0, spriteHeight / 2, 0), boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider == null)
            {
                //Move vertically.
                transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
            }

            //Checks if there is something you can collide with horizontally.
            hit = Physics2D.BoxCast(transform.position - new Vector3(0, spriteHeight / 2, 0), boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider == null)
            {
                //Move horizontally.
                transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
            }
            count += 1;
            if (count == 20)
            {
                count = 0;
            }
        }
        
    }
}
