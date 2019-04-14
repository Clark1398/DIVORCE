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
        if (lift)
        {
            if (up)
            {
                anim.Play("Down");
                StartCoroutine(SwitchOn(this.GetComponent<Collider>()));
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
            if (!up)
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
        col.enabled = false;

        yield return new WaitForSeconds(5f);

        up = false;

        col.enabled = true;
    }
}
