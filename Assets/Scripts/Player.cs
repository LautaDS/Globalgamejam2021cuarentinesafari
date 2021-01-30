using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject flashlight;
    private Vector2 direction;
    [SerializeField] private float speed = 10f;
    private bool facingRight = true;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(0f, 0f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }
    #region InputReciever
    public void OnMovement(InputAction.CallbackContext context)
    {
        // Store data from inputs  
        movement = context.ReadValue<Vector2>();
    }

    public void OnAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           

        }
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {


        }
    }

    public void OnStart(InputAction.CallbackContext context)
    {
        if (context.performed)
        {


        }
    }

    #endregion

    private void Move()
    {
        if(movement.x < 0.1 && movement.x > -0.1 && movement.y < 0.1 && movement.y > -0.1)
        {
            rb.velocity = new Vector2(rb.velocity.x /3 , rb.velocity.y / 3);
        } else
        {
            rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
        }
        
        // check horizontal velocity to use flip
       
    }

    void Flip()
    {
        if (rb.velocity.x < -0.1)
            {
            facingRight = false ;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
            }
            else
            {
            facingRight = true;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
       
        
    }

    private void AdjustFlashlight()
    {
        flashlight.transform.position = direction;
        
    }
        
}
