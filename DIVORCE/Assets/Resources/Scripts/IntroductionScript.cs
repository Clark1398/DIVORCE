using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionScript : MonoBehaviour
{
    public GameObject p1, p2, p3, p4, blank;

    public Animator anim;

    void Start()
    {
        StartCoroutine(Change(p1, p2));
    }

    IEnumerator Change(GameObject screen, GameObject next)
    {
        anim.Play("Fade Back");
        screen.SetActive(true);

        yield return new WaitForSeconds(2f);

        anim.Play("Fade");

        yield return new WaitForSeconds(2f);

        screen.SetActive(false);

        yield return new WaitForSeconds(1f);

        StartCoroutine(Change2(next, p3));
    }


    IEnumerator Change2(GameObject screen, GameObject next)
    {
        anim.Play("Fade Back");
        screen.SetActive(true);

        yield return new WaitForSeconds(2f);

        anim.Play("Fade");

        yield return new WaitForSeconds(2f);

        screen.SetActive(false);

        yield return new WaitForSeconds(1f);

        StartCoroutine(Change3(next, p4));
    }


    IEnumerator Change3(GameObject screen, GameObject next)
    {
        anim.Play("Fade Back");
        screen.SetActive(true);

        yield return new WaitForSeconds(2f);

        anim.Play("Fade");

        yield return new WaitForSeconds(2f);

        screen.SetActive(false);

        yield return new WaitForSeconds(1f);

        StartCoroutine(Change4(next));
    }


    IEnumerator Change4(GameObject screen)
    {
        anim.Play("Fade Back");
        screen.SetActive(true);

        yield return new WaitForSeconds(2f);

        anim.Play("Fade");

        yield return new WaitForSeconds(2f);

        screen.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("MainMenuScene");
    }
}
