using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator anim;

    public void OnTriggerEnter(Collider other)
    {
        anim.Play("Open");
    }

    public void OnTriggerExit(Collider other)
    {
        anim.Play("Close");
    }
}
