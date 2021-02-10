using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Polilla : MonoBehaviour
{
    public Player player;
    public float distanceFromLight;
    public float speed;
    public bool closeToPlayer;
    private Rigidbody2D rb;
    public float maxSpeed;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(closeToPlayer)
        {
            FindLight();
        }
    }

    public void FindLight()
    {
        float differenceInYAxis = transform.position.y - player.gameObject.transform.position.y;
       if (differenceInYAxis >  1 && differenceInYAxis < -1)
        {
            rb.AddForce(new Vector2(0, speed), ForceMode2D.Impulse);
            
                rb.velocity = new Vector2(0,maxSpeed);
        }
       else if (differenceInYAxis < 1 && differenceInYAxis > -1)
        {
            rb.AddForce(new Vector2(-1 * speed, 0), ForceMode2D.Impulse);
           
                rb.velocity = new Vector2(maxSpeed, 0);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("flashlight"))
        {
            closeToPlayer = true;
            SceneManager.LoadScene("EndScreen");
        }
        if(collision.CompareTag("Poligoal"))
        {
            player.UpdateLevelOfPuzzles();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("flashlight"))
        {
            closeToPlayer = false;
        }
    }
}
