using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : MonoBehaviour
{
    public float lightAmount;
    private bool insideOfLight;
    public float lightNeeded;
    public Animator animator;
    public Player player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(insideOfLight)
        {
            lightAmount = lightAmount + Time.deltaTime;
            if(lightAmount < lightNeeded && lightAmount > 0)
            {
                animator.SetBool("iluminada", true);
            }
            if(lightAmount > lightNeeded && player.levelOfPuzzles < 1)
            {
                animator.SetBool("iluminadadeltodo", true);
                player.levelOfPuzzles = 1;
                player.AdjustDoors();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("flashlight"))
        {
            insideOfLight = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("flashlight"))
        {
            insideOfLight = false;
        }
    }
}
