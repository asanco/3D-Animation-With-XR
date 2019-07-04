using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouthControl : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Text latestValue;
    public int mouthValue = 0;

    void Update()
    {
        mouthValue = System.Convert.ToInt32(latestValue.text.ToString());
        skinnedMeshRenderer.SetBlendShapeWeight(0, mouthValue);
    }
}
