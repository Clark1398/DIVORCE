using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator anim;

    public bool lift;
    public bool up;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");

        if (lift)
        {
            if (up)
            {
                anim.Play("Down");
                other.enabled = false;
                StartCoroutine(SwitchOn(other));
            }
            else
            {
                anim.Play("Open");
            }
        }
        else
        {
            anim.Play("Open");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (lift)
        {
            if (up)
            {
                up = false;
            }
            else
            {           
                up = true;
            }
        }
        else
        {
            anim.Play("Close");
        }
    }

    IEnumerator SwitchOn(Collider col)
    {
        yield return new WaitForSeconds(5.0f);

        col.enabled = true;
    }
}
