using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour
{
    public Player player;
    public GameObject[] trees;
    public Animator animator;
    public int currentTree;
    public int winTree;
    public int lastTree;
    public int speed = 1;
    public int targetTree;
    // Start is called before the first frame update
    void Start()
    {
        currentTree = 0;
        lastTree = currentTree;
        transform.position = trees[currentTree].gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(transform.position != trees[currentTree].gameObject.transform.position)
        {
            MoveToTree(targetTree);
        }
    }

    public void MoveToTree(int nextTree)
    {
        Debug.Log("entramos a movetotree");
        if (currentTree != nextTree && currentTree != winTree)
        {
            Debug.Log("Sileesestotendriaquemoverse");
            float step = speed * Time.deltaTime;
            Vector3 newposition = new Vector3(trees[nextTree].gameObject.transform.position.x, trees[nextTree].gameObject.transform.position.y, trees[nextTree].gameObject.transform.position.z);
            transform.position = newposition;

            animator.SetTrigger("OwlGoFly");
            lastTree = currentTree;
            currentTree = nextTree;
            Debug.Log("comonovaasalirdeaca'");
        }
        if (currentTree == winTree)
        {
            animator.SetBool("OwlWin", true);
        }
        Debug.Log("obvioquesaliodeaca");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("flashlight"))
        {
            if (player.direction.x == -1f)
            {
                targetTree = lastTree;
               
            }
            if(player.direction.x == 1f)
            {
                targetTree = currentTree + 1;
                
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("flashlight"))
        {
           
        }
    }
}
