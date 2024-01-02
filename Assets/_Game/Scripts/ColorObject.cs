using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : MonoBehaviour
{
    public ColorType colorType;

    [SerializeField] private ColorData colorData;
    [SerializeField] private MeshRenderer meshRenderer;

    public void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        meshRenderer.material = colorData.GetColorMat(colorType);
    }

}
