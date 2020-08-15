using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour {
   
    Slider slider;
    [SerializeField]
    Material baseMat;
    [SerializeField]
    string sliderValue;
    [SerializeField]
    int blendshapeIndex;

    [SerializeField]
    float mSize = 0;


    [SerializeField]
    SkinnedMeshRenderer mesh;

    [SerializeField]
    Transform bone;

    public enum Type { bone, color, blendshape, hairArray, hornArray};
    public Type type;
	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        //BlendShapeController.onRandomise.AddListener(UpdateRandomise);
        slider.value = mesh.GetBlendShapeWeight(blendshapeIndex);
    }
	
	// Update is called once per frame
	void Update () {
		mesh.SetBlendShapeWeight(blendshapeIndex, slider.value);
    }

    void UpdateRandomise()
    {
        switch (type)
        {
            
            case Type.blendshape:
                {
                    //slider.value = mesh.GetBlendShapeWeight(blendshapeIndex);
                    break;
                }
            case Type.color:
                {
                    slider.value = baseMat.GetFloat(sliderValue);
                    break;
                }
            case Type.bone:
                {
                    slider.value = bone.localScale.x;
                    break;
                }
            case Type.hairArray:
                {
                    slider.value = BlendShapeController.HairArray;
                    break;
                }
            case Type.hornArray:
                {
                    slider.value = BlendShapeController.HornArray;
                    break;
                }
        }
      
        
    }
}
