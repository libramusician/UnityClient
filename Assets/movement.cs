using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    Vector3 r = new Vector3(0, 1, 0);
    Vector3 l = new Vector3(0, -1, 0);
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("walking");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            animator.SetBool(isWalkingHash, true);
        }
        else {
            animator.SetBool(isWalkingHash, false);
        }
        handleRotation();

    }

    void handleRotation() {
        if (Input.GetKey("d"))
        {
            transform.Rotate(r);
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(l);
        }
    }
}
