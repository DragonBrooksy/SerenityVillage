using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    private float cooldown = 0.5f;
    private float lastUsage;
    private int currentTool = 1;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetInteger("Tool", currentTool);
    }

    private void FixedUpdate()
    {
        //Gets movement direction.
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float spriteHeight = transform.localScale.y * spriteRenderer.sprite.bounds.size.y;

        //Gets player direction, and sends this to the animator to display the correct walking animation.
        moveDelta = new Vector3(x,y,0);
        animator.SetFloat("Horizontal", moveDelta.x);
        animator.SetFloat("Vertical", moveDelta.y);
        animator.SetFloat("Speed", moveDelta.sqrMagnitude);

        if (Time.time - lastUsage > cooldown)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (currentTool == 1)
                {
                    currentTool = 3;
                    animator.SetInteger("Tool", currentTool);
                }
                else
                {
                    currentTool -= 1;
                    animator.SetInteger("Tool", currentTool);
                }
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentTool == 3)
                {
                    currentTool = 1;
                    animator.SetInteger("Tool", currentTool);
                }
                else
                {
                    currentTool += 1;
                    animator.SetInteger("Tool", currentTool);
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                lastUsage = Time.time;
                UseTool();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Interact();
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
            }
        }

    }

    private void UseTool()
    {
        animator.SetTrigger("UseTool");
        if (currentTool == 1)
        {
            float spriteHeight = transform.localScale.y * spriteRenderer.sprite.bounds.size.y;
            hit = Physics2D.BoxCast(transform.position - new Vector3(0, spriteHeight / 2, 0), boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("FarmableLand"));
            if (hit.collider != null)
            {
                gameObject.SendMessage("Till");
            }
        }
        
    }

    private void Interact()
    {

    }
}
