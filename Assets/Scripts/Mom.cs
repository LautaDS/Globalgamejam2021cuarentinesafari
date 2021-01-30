using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mom : MonoBehaviour
{
    public Door[] doors;
    private int levelOfPuzzles;
    public Dialogs[] dialogs;

    private void Awake()
    {
        levelOfPuzzles = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustDoors()
    {
        switch (levelOfPuzzles)
        {
            case 0:
                doors[levelOfPuzzles].isOpen = true;
                break;
            case 1:
                doors[levelOfPuzzles].isOpen = true;
                break;
            case 2:
                doors[levelOfPuzzles].isOpen = true;
                break;


            default:
                break;
        }
    }



}
