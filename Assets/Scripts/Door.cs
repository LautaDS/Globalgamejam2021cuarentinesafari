using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen;
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        if(isOpen == false)
        {
           
            // abrir puerta
        }
        isOpen = true;
    }

    public void CloseDoor()
    {
        if(isOpen == true)
        {
            // cerrar
        }
        isOpen = false;
    }
}
