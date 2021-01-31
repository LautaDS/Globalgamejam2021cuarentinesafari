using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    public Transform flashlight;
    public Vector2 direction;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float distanceFromPlayer = 1.5f;
   
    public GameObject mom;
    public float distanceToMom;
    public GameObject dialogBox;
    public TMP_Text dialogText;
    public string[] dialogLines;
    public int levelOfPuzzles = 0;

    public Door[] doors;
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
       
        if (PauseMenu.isPaused == false)
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
            TurnOnAndOffFlashlight();
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

    private void TurnOnAndOffFlashlight()
    {
        if(flashlight.gameObject.activeSelf)
        {
            flashlight.gameObject.SetActive(false);
        }
        else
        {
            flashlight.gameObject.SetActive(true);
        }
    }

    #region dialog and doors

    IEnumerator Type(int levelOfPuzzles)
    {
        dialogText.text = "";
        foreach (char letter in dialogLines[levelOfPuzzles].ToCharArray())
        {
            Debug.Log("Entramos aca");
            dialogText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

        if (levelOfPuzzles >= 3)
        {
            Debug.Log("ganaste");
            yield return new WaitForSeconds(1f);
            // win condition 
        }

    }
    public void WriteDialog(int lineofdialog)
    {
        dialogText.text = "";
        dialogText.text = dialogLines[lineofdialog];
    }
    public void ActivateDialog()
    {
            dialogBox.SetActive(true);
            WriteDialog(levelOfPuzzles);

    }
    public void DeactivateDialog()
    {
        dialogBox.SetActive(false);
    }

    public void AdjustDoors()
    {
        switch (levelOfPuzzles)
        {
            case 0:

                break;
            case 1:
                doors[levelOfPuzzles].OpenDoor();
                break;
            case 2:
                doors[levelOfPuzzles].OpenDoor();
                break;
            case 3:
                doors[levelOfPuzzles].OpenDoor();
                break;

            default:
                break;
        }

      
    }

    public void UpdateLevelOfPuzzles()
    {
        levelOfPuzzles++;
        AdjustDoors();
        if (levelOfPuzzles >= 3)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
    #endregion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Mom")
        { 
        ActivateDialog();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Mom")
        {
            DeactivateDialog();
        }
    }

}
