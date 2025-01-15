using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    Animator animator;

    public static int amountOfTimesUsedBolts = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (amountOfTimesUsedBolts >= 2)
        {
            animator.Play("HeartDieAnim");
        }
    }
}
