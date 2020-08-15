using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BlendShapeController : MonoBehaviour {
    [SerializeField]
    SkinnedMeshRenderer BaseModel;
    [SerializeField]
    SkinnedMeshRenderer ArmorModel;
    [SerializeField]
    SkinnedMeshRenderer FaceModel;
    [SerializeField]
    SkinnedMeshRenderer HornModel;
    [SerializeField]
    GameObject[] HairStyles;

    [SerializeField]
    Transform torsoBone;
    [SerializeField]
    Transform headBone;
    float sliderValueBody;
    float sliderValueEyeP;
    float sliderValueEyeS;
    float sliderValueNoseS;
    float sliderValueChin;
    [SerializeField]
    ColorPicker colorPicker;

    public static UnityEvent onRandomise = new UnityEvent();
    public static int HairArray;
    public static int HornArray;

    private void Start()
    {
        Randomise();
    }


 
    public void SetSliderPrimaryColor(float sValue)
    {
        BaseModel.sharedMaterial.SetFloat("_Weight1", sValue);
    }
    public void SetSliderSecondaryColor(float sValue)
    {
        BaseModel.sharedMaterial.SetFloat("_Weight2", sValue);
    }
    public void SetSliderTertiaryColor(float sValue)
    {
        BaseModel.sharedMaterial.SetFloat("_Weight3", sValue);
    }

    public void SetSliderHornColor(float sValue)
    {
        HornModel.sharedMaterial.SetFloat("_Weight1", sValue);
    }
    public void SetySliderArmorPrimary(float sValue)
    {
        ArmorModel.sharedMaterial.SetFloat("_Weight1", sValue);
    }
    public void SetySliderArmorSecondary(float sValue)
    {
        ArmorModel.sharedMaterial.SetFloat("_Weight2", sValue);
    }
    public void SetySliderArmorTertiary(float sValue)
    {
        ArmorModel.sharedMaterial.SetFloat("_Weight3", sValue);
    }


    public void Randomise()
    {
        sliderValueBody = Random.Range(-100, 100);
        sliderValueEyeP = Random.Range(0, 100);
        sliderValueEyeS = Random.Range(0, 100);
        sliderValueNoseS = Random.Range(0, 100);
        sliderValueChin = Random.Range(0, 100);
        BaseModel.SetBlendShapeWeight(0, sliderValueBody);
        ArmorModel.SetBlendShapeWeight(0, sliderValueBody);
        BaseModel.SetBlendShapeWeight(1, sliderValueBody * -1);
        ArmorModel.SetBlendShapeWeight(1, sliderValueBody * -1);
        FaceModel.SetBlendShapeWeight(0, GetRandomValue());
       FaceModel.SetBlendShapeWeight(1, GetRandomValue());
        FaceModel.SetBlendShapeWeight(2, GetRandomValue());
        FaceModel.SetBlendShapeWeight(3, GetRandomValue());
        FaceModel.SetBlendShapeWeight(4, GetRandomValue());
        FaceModel.SetBlendShapeWeight(5, GetRandomValue());
        FaceModel.SetBlendShapeWeight(6, GetRandomValue());
        FaceModel.SetBlendShapeWeight(7, GetRandomValue());
        FaceModel.SetBlendShapeWeight(8, GetRandomValue());
        FaceModel.SetBlendShapeWeight(9, GetRandomValue());

        float randomValueTorso = Random.Range(0.9f, 1.1f);
        torsoBone.localScale = new Vector3(randomValueTorso, randomValueTorso, randomValueTorso);

        float randomValueHead = Random.Range(0.9f, 1.1f);
        headBone.localScale = new Vector3(randomValueHead, randomValueHead, randomValueHead);

        HornArray = Random.Range(0, 3);
        SetHornStyle(HornArray);

        HornModel.SetBlendShapeWeight(3, GetRandomValue());
        HornModel.sharedMaterial.SetColor("_ColorPrim1", Random.ColorHSV(0f, 1f, 0.6f, 0.8f, 0.2f, 0.3f));
        HornModel.sharedMaterial.SetColor("_ColorPrim2", Random.ColorHSV(0f, 1f, 0.6f, 0.8f, 0.0f, 0.2f));

        // colorPicker.SetRandomColor();
        BaseModel.sharedMaterial.SetFloat("_Weight3", Random.Range(-0.5f, 0.0f));
        BaseModel.sharedMaterial.SetFloat("_Weight2", Random.Range(-0.5f, 0.0f));
        BaseModel.sharedMaterial.SetFloat("_Weight1", Random.Range(-0.5f, 0.0f));

        BaseModel.sharedMaterial.SetColor("_ColorPrim1", Random.ColorHSV());
     
        BaseModel.sharedMaterial.SetColor("_ColorPrim2", Random.ColorHSV());
      
        BaseModel.sharedMaterial.SetColor("_ColorSec1", Random.ColorHSV());
  
        BaseModel.sharedMaterial.SetColor("_ColorSec2", Random.ColorHSV());
     
        BaseModel.sharedMaterial.SetColor("_ColorTert1", Random.ColorHSV());
    
        BaseModel.sharedMaterial.SetColor("_ColorTert2", Random.ColorHSV());

        ArmorModel.sharedMaterial.SetColor("_ColorPrim1", Random.ColorHSV(0f, 1f, 0.6f, 0.8f, 0.6f, 0.8f));

        ArmorModel.sharedMaterial.SetColor("_ColorPrim2", Random.ColorHSV(0f, 1f, 0.6f, 0.8f, 0.6f, 0.8f));

        ArmorModel.sharedMaterial.SetColor("_ColorSec1", Random.ColorHSV(0f, 1f, 0.3f, 0.4f, 0f, 0.2f));

        ArmorModel.sharedMaterial.SetColor("_ColorSec2", Random.ColorHSV(0f, 1f, 0.3f, 0.4f, 0f, 0.2f));

        ArmorModel.sharedMaterial.SetColor("_ColorTert1", Random.ColorHSV(0f, 1f, 0.6f, 0.8f, 0.1f, 0.5f));

        ArmorModel.sharedMaterial.SetColor("_ColorTert2", Random.ColorHSV(0f, 1f, 0.6f, 0.8f, 0.1f, 0.5f));

        ArmorModel.sharedMaterial.SetFloat("_Weight1", Random.Range(-0.5f, 0.0f));
        ArmorModel.sharedMaterial.SetFloat("_Weight2", Random.Range(-0.5f, 0.0f));
        ArmorModel.sharedMaterial.SetFloat("_Weight3", Random.Range(-0.5f, 0.0f));

        for (int i = 0; i < HairStyles.Length; i++)
        {
            HairStyles[i].SetActive(false);
        }
        HairArray = Random.Range(0, HairStyles.Length);
        HairStyles[HairArray].SetActive(true);

        onRandomise.Invoke();
        }

    float GetRandomValue()
    {
        return Random.Range(0, 100);
    }


    public void SetSliderValueBody(float sValue)
    {
       
        BaseModel.SetBlendShapeWeight(0, sValue );
        ArmorModel.SetBlendShapeWeight(0, sValue);
         BaseModel.SetBlendShapeWeight(1, -sValue);
        ArmorModel.SetBlendShapeWeight(1, -sValue );
    }
    public void SetEyebrowSize(float sValue)
    {
        FaceModel.SetBlendShapeWeight(0, sValue);
    }
    public void SetNoseSize(float sValue)
    {
        FaceModel.SetBlendShapeWeight(1, sValue);
    }
    public void SetMouthSize(float sValue)
    {
        FaceModel.SetBlendShapeWeight(2, sValue);
    }
    public void SetFaceWidth(float sValue)
    {
        FaceModel.SetBlendShapeWeight(3, sValue );
    }
    public void SetEyeAngle(float sValue)
    {
        FaceModel.SetBlendShapeWeight(4, sValue );
    }
    public void SetEarPointiness(float sValue)
    {
        FaceModel.SetBlendShapeWeight(5, sValue );
    }
    public void SetEarSize(float sValue)
    {
        FaceModel.SetBlendShapeWeight(6, sValue );
    }
    public void SetEyePlacement(float sValue)
    {
        FaceModel.SetBlendShapeWeight(7, sValue );
    }
    public void SetEyeSize(float sValue)
    {
        FaceModel.SetBlendShapeWeight(8, sValue );
    }
    public void SetPupilSize(float sValue)
    {
        FaceModel.SetBlendShapeWeight(9, sValue );
    }
    public void SetTorsoSize(float sValue)
    {
        torsoBone.localScale = new Vector3(sValue, sValue, sValue);
    }

    public void SetHeadSize(float sValue)
    {
        headBone.localScale = new Vector3(sValue, sValue, sValue);
    }

    public void ShowArmor(bool visible)
    {
        ArmorModel.enabled = visible;
    }

    public void SetHornStyle(float sValue)
    {
        for (int i = 0; i < 3; i++)
        {
            HornModel.SetBlendShapeWeight(i, 0f);
        }
        HornModel.SetBlendShapeWeight((int)sValue, 100f);
    }

    public void SetHornSize(float sValue)
    {
        HornModel.SetBlendShapeWeight(3,sValue);
    }

    public void SetHairStyle(float sValue)
    {
        for (int i = 0; i < HairStyles.Length; i++)
        {
            HairStyles[i].SetActive(false);
        }

        HairStyles[(int)sValue].SetActive(true);
    }
}

