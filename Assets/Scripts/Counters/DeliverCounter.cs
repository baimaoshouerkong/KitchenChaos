using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DeliverCounter : BaseCounter
{
    public static DeliverCounter Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                DeliveryManager.Instance.DeliveryRecipe(plateKitchenObject);
                plateKitchenObject.DestroySelf();
            }
            else
            {
                Debug.Log("Player is holding something that is not a plate!");
            }
        }
        else
        {
            Debug.Log("Player is not holding anything!");
        }
    }
}
