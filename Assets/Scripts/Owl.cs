using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour
{
    public Player player;
    public GameObject[] trees;
    public Animator animator;
    public int currentTree;
    public int speed = 1;
    public int targetTree;

    private OwlStates lastState;
    private OwlStates currentState;



    // Start is called before the first frame update
    void Start()
    {
        currentTree = 0;

        transform.position = trees[currentTree].gameObject.transform.position;

        currentState = OwlStates.IDLE;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        switch (currentState)
        {
            case OwlStates.FLYING:
                break;
            case OwlStates.IDLE:

                break;
            case OwlStates.ENDED:
                break;
        }


        /*
        if(transform.position != trees[currentTree].gameObject.transform.position)
        {
            MoveToTree(targetTree);
        }*/
    }

    private void ChangeState(OwlStates newState)
    {
        if (currentState != newState)
        {
            lastState = currentState;
            currentState = newState;
        }
    }

    private bool win = false; 

    public void MoveToTree()
    {
        if (currentState == OwlStates.IDLE)
        {
            ChangeState(OwlStates.FLYING);
            StartCoroutine(Move(trees[targetTree].transform.position));
            targetTree++;

            if (targetTree == trees.Length)
            {
                win = true;
            }
        }

    }


    IEnumerator Move(Vector3 newPos)
    {


        //IGUALES FLOTANTES ESTA MAL VISTO 0.0000001 == 0.0001
        //OTRA FORMA ES MATHF.APROX()/*
        
        Vector3 step = (newPos - transform.position).normalized;

        while (Vector3.Distance(transform.position, newPos) > 0.1f)
        {
            transform.position += step * Time.deltaTime;
            yield return null;
        }
       
        if (win)
            ChangeState(OwlStates.ENDED);
        else
           ChangeState(OwlStates.IDLE);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("flashlight"))
        {
            Debug.Log("ASDSADASD");
            MoveToTree();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("flashlight"))
        {
            MoveToTree();
        }
    }

    private enum OwlStates
    {
        IDLE,
        FLYING,
        ENDED
    }
}
