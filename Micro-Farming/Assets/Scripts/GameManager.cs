using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private int curDay;
    [SerializeField] private int money;
    [SerializeField] private int cropInventory;
    
    //Encapsulamiento
    public int CurDay { get => curDay; }
    
    public CropData selectedCropToPlant;
    public TextMeshProUGUI statsText;

    public event UnityAction onNewDay;
    
    //Singleton
    public static GameManager instance;

    

    private void OnEnable()
    {
        Crop.onPlantCrop += OnPlantCrop;
        Crop.onHarvestCrop += OnHarvestCrop;
    }

    private void OnDisable()
    {
        Crop.onPlantCrop -= OnPlantCrop;
        Crop.onHarvestCrop -= OnHarvestCrop;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        UpdateStatesText();
        InvokeRepeating(nameof(SetNextDay), 3.0f,3.0f);
    }

    public void SetNextDay()
    {
        curDay++;
        onNewDay?.Invoke();
        UpdateStatesText();
    }

    public void OnPlantCrop(CropData crop)
    {
        cropInventory--;
        UpdateStatesText();
    }

    public void OnHarvestCrop(CropData crop)
    {
        money += crop.sellPrice;
        UpdateStatesText();
    }

    public void PurchaseCrop(CropData crop)
    {
        money -= crop.purchasePrice;
        cropInventory++;
        UpdateStatesText();
    }

    public bool CanPlantCrop()
    {
        return cropInventory > 0;
    }

    public void OnBuyCropButton(CropData crop)
    {
        if (money >= crop.purchasePrice)
        {
            PurchaseCrop(crop);
        }
    }

    void UpdateStatesText()
    {
        statsText.text = $"Día: {CurDay}\n Dinero: {money}\n Semillas:{cropInventory}";
    }
}
