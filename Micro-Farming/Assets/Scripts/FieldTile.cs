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
        if(!tilled) return;
        
        curCrop = Instantiate(cropPrefab, transform).GetComponent<Crop>();
        curCrop.Plant(crop);

        GameManager.instance.onNewDay += OnNewDay;

    }

    void Till()
    {
        tilled = true;
        sr.sprite = tilledSprite;
    }

    void Water()
    {
        sr.sprite = wateredTilledSprite;
        if (HasCrop())
        {
            curCrop.Water();
        }
    }

    void OnNewDay()
    {
        if (curCrop == null)
        {
            tilled = false;
            sr.sprite = grassSprite;
            GameManager.instance.onNewDay -= OnNewDay;
        }
        else if(curCrop != null)
        {
            sr.sprite = tilledSprite;
            curCrop.NewDayCheck();
        }
    }

    bool HasCrop()
    {
        return curCrop != null;
    }   
}
