using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop Data", menuName = "New Crop Data")]
public class CropData : ScriptableObject
{
   [Header("1. Configuracion de Crecimientos \n")]
   public int daysToGrow;
   public Sprite[] growProgressSprites;
   public Sprite readyToHarvestSprite;
   
   [Header("2. Configuracion de Comercio \n")]
   [Range(1,3000)] public int purchasePrice;
   [Range(1,3000)] public int sellPrice;
}
