using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private Animator anim;
    private int timer = 0;
    private int minuteSegment = 0;
    private int hourSegment = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("Minute", minuteSegment);
        anim.SetFloat("Hour", minuteSegment);
    }

    private void FixedUpdate()
    {
        timer += 1;
        if (timer == 720)
        {
            minuteSegment += 1;
            timer = 0;
        }
        if (minuteSegment == 4)
        {
            minuteSegment = 0;
            hourSegment += 1;
        }
        if (hourSegment == 19)
        {
            hourSegment = 0;
        }
        anim.SetFloat("Minute", minuteSegment);
        anim.SetFloat("Hour", minuteSegment);
    }
}
