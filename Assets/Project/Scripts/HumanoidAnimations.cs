using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidAnimations : MonoBehaviour
{
    private Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    public void SetMovementFloat(float value)
    {
        _anim.SetFloat("Move", value);
    }
    public float SetCorrectAnimation(float desiredRotationAngle, int angleThreshold, int inputVerticalDirection)
    {
        float currentAnimationSpeed = _anim.GetFloat("Move");
        Debug.Log(desiredRotationAngle);
        if(desiredRotationAngle > angleThreshold || desiredRotationAngle < -angleThreshold)
        {
            if(Mathf.Abs(currentAnimationSpeed) < .2f)
            {
                currentAnimationSpeed += inputVerticalDirection * Time.deltaTime * 2;
                currentAnimationSpeed = Mathf.Clamp(currentAnimationSpeed, -.2f, .2f);
            }
            SetMovementFloat(currentAnimationSpeed);
        }
        else
        {
            if(currentAnimationSpeed < 1)
            {
                currentAnimationSpeed += inputVerticalDirection * Time.deltaTime * 2;
            }
            SetMovementFloat(Mathf.Clamp(currentAnimationSpeed, -1, 1));
        }

        return Mathf.Abs(currentAnimationSpeed);
    }
}
