using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://docs.unity3d.com/ScriptReference/Vector3.RotateTowards.html

public class LookAtScript : MonoBehaviour
{
    public GameObject target;

    float speed = 1.0f;

    void Update()
    {
        if (target != null)
        {
            Vector3 targetDir = target.transform.position - transform.position;

            // The step size is equal to speed times frame time.
            float step = speed * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}
