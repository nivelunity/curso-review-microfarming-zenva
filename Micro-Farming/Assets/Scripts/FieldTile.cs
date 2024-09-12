using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTile : MonoBehaviour
{
    public GameObject cropPrefab;

    public SpriteRenderer sr;
    private bool tilled;

    [Header("Sprites")] 
    public Sprite grassSprite;
    public Sprite tilledSprite;
    public Sprite wateredTilledSprite;

    private Crop curCrop;
    private void Start()
    {
        // Default Sprite
        sr.sprite = grassSprite;
    }

    public void Interact()
    {
        if (!tilled)
        {
            Till();
        }
        else if (!HasCrop() && GameManager.instance.CanPlantCrop())
        {
            PlantNewCrop(GameManager.instance.selectedCropToPlant);
        }else if (HasCrop() && curCrop.CanHarvest())
        {
            curCrop.Harvest();
        }
        else
        {
            Water();
        }
    }

    void PlantNewCrop(CropData crop)
    {
        
    }

    void Till()
    {
        
    }

    void Water()
    {
        
    }

    void OnNewDay()
    {
        
    }

    bool HasCrop()
    {
        return curCrop != null;
    }   
}
