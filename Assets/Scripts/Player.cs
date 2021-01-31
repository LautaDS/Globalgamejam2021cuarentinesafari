using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    public Transform flashlight;
    private Vector2 direction;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float distanceFromPlayer = 1.5f;
    public bool[] winCondittionMeet = new bool[3];

    public bool talking;

    public Mom mom;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(0f, 0f);
       
        for (int i = 0; i < winCondittionMeet.Length; i++) { winCondittionMeet[i] = false; }
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
       
        if (PauseMenu.isPaused == false || !talking)
        { 
        Move();
        AdjustDirection();
        AdjustFlashlight();
        }
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

    private void AdjustDirection()
    {

        // Este matete ajusta el vector2 direction para con el poder comunicarle a la linterna y posteriormente al buho, para donde se esta mirando.
        if(rb.velocity.y > 0.8 && rb.velocity.x < 0.8)
             if (rb.velocity.y > 0.8 && rb.velocity.x > -0.8)
            {
                direction = new Vector2(0f, 1f);
            }
        if (rb.velocity.y < -0.8 && rb.velocity.x < 0.8)
            if (rb.velocity.y < -0.8 && rb.velocity.x > -0.8)
            {
                direction = new Vector2(0f, -1f);
            }

        if (rb.velocity.x > 0.8 && rb.velocity.y < 0.8)
            if (rb.velocity.x > 0.8 && rb.velocity.y > -0.8)
            {
                direction = new Vector2(1f, 0f);
            }
        if (rb.velocity.x < -0.8 && rb.velocity.y < 0.8)
            if (rb.velocity.x < -0.8 && rb.velocity.y > -0.8)
            {
                direction = new Vector2(-1f, 0f);
            }

    }

    private void AdjustFlashlight()
    {
        flashlight.transform.localPosition = new Vector2(direction.x * distanceFromPlayer, direction.y * distanceFromPlayer);
        flashlight.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        if (direction == new Vector2(-1f,0f))
        {
            flashlight.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        if (direction == new Vector2(1f, 0f))
        {
            flashlight.transform.rotation = Quaternion.Euler(0f, 0f, 260f);
        }
        if (direction == new Vector2(0f, 1f))
        {
            flashlight.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (direction == new Vector2(0f, -1f))
        {
            flashlight.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
    }
    
    public void StartTalking()
    {
        talking = true;
        
    }


}
