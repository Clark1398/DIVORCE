using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DoorScript : MonoBehaviour
{
    public Animator anim;
    public AudioSource audioSource;

    public AudioClip doorSFX;
    public AudioClip liftSFX;

    public Light light1, light2;

    public bool lift;
    public bool up;

    GameObject player, pos;

    void Start()
    {
        if (lift)
        {
            player = GameObject.Find("PlayerController");
            pos = GameObject.Find("PlayerPosition");
            light1.color = Color.green;
            light2.color = Color.green;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (lift)
        {
            if (up)
            {
                player.transform.parent = pos.transform;
                player.transform.rotation = pos.transform.rotation;
                player.GetComponent<Rigidbody>().useGravity = false;
                player.GetComponent<RigidbodyFirstPersonController>().enabled = false;
                anim.Play("Down");
                //audioSource.clip = liftSFX;
                //audioSource.Play();
                StartCoroutine(SwitchOn(this.GetComponent<Collider>()));
            }
            else
            {
                player.transform.parent = pos.transform;
                player.transform.rotation = pos.transform.rotation;
                player.GetComponent<Rigidbody>().useGravity = false;
                player.GetComponent<RigidbodyFirstPersonController>().enabled = false;
                anim.Play("Open");
                StartCoroutine(GoUp());
            }
        }
        else
        {
            anim.Play("Open");
            audioSource.clip = doorSFX;
            audioSource.Play();
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
            audioSource.clip = doorSFX;
            audioSource.Play();
        }
    }

    IEnumerator GoUp()
    {
        light1.color = Color.red + Color.yellow;
        light2.color = Color.red + Color.yellow;

        yield return new WaitForSeconds(2.75f);

        light1.color = Color.green;
        light2.color = Color.green;

        player.transform.parent = null;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<RigidbodyFirstPersonController>().enabled = true;
    }

    IEnumerator SwitchOn(Collider col)
    {
        light1.color = Color.red + Color.yellow;
        light2.color = Color.red + Color.yellow;

        col.enabled = false;


        yield return new WaitForSeconds(2.75f);

        player.transform.parent = null;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<RigidbodyFirstPersonController>().enabled = true;

        up = false;

        light1.color = Color.red;
        light2.color = Color.red;

        yield return new WaitForSeconds(5f);

        light1.color = Color.green;
        light2.color = Color.green;

        col.enabled = true;
    }
}
