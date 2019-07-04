using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkControl : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public int blinkValue = 0;
    private float blinkSpeed = 0.0001f;

    private void Start()
    {
        RandomDelay();
    }

    private void RandomDelay()
    {
        float delay = UnityEngine.Random.Range(2, 10);
        StartCoroutine(Blink(delay));
    }

    private IEnumerator Blink(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (blinkValue == 0)
        {
            float counter = 0f;
            while (blinkValue < 120)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(0, blinkValue);
                blinkValue += 3;
                while (counter < blinkSpeed)
                {
                    counter += Time.deltaTime;
                    yield return null;
                }
                counter = 0;
            }
            while (blinkValue > 0)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(0, blinkValue);
                blinkValue -= 3;
                while (counter < blinkSpeed)
                {
                    counter += Time.deltaTime;
                    yield return null;
                }
                counter = 0;
            }

        }
        
        RandomDelay();
    }
}

