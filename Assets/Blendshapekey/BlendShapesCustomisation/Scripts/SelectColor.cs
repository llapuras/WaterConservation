using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectColor : MonoBehaviour {
    [SerializeField]
    string ColorName;
    [SerializeField]
    Material CharacterMaterial;
    [SerializeField]
    ColorPicker colorPicker;
    [SerializeField]
    Image image;
    Toggle button;
    bool toggleBool = false;
    [SerializeField]
    SkinnedMeshRenderer BaseModel;
    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();

    }
	
	// Update is called once per frame
	void Update () {
       image.color= CharacterMaterial.GetColor(ColorName);
        if (toggleBool)
        {  
            
            image.color = colorPicker.Color;
            CharacterMaterial.SetColor(ColorName, colorPicker.Color);
        }
        
    }

  


    public void SwapBool(bool toggle)
    {
        colorPicker.Color = CharacterMaterial.GetColor(ColorName);
        print(toggle);
        toggleBool = toggle;
        print(toggleBool);
    }
}
