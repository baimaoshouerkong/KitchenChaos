using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    public event EventHandler OnPlayerGrabbedObject;
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            if (StoreManager.Instance.TryGetKithcenObjectSO(kitchenObjectSO, player.GetCatchNumber()))
            {
                KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
                OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
            }
        }
        else
        {
            if (StoreManager.Instance.TryGetKithcenObjectSO(kitchenObjectSO, player.GetCatchNumber()))
            {
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(kitchenObjectSO))
                        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }

}
