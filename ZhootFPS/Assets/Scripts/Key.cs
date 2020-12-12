using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] KeyInventory[] keys;

    [System.Serializable]
    private class KeyInventory
    {
        public KeyType keyType;
        public int keyAmount;
        public GameObject keyImage;
    }

    public int GetCurrentKeyAmount(KeyType keyType)
    {
        return GetKeyInventory(keyType).keyAmount;
    }

    public void ReduceKeyAmount(KeyType keyType, int keyCost)
    {
        GetKeyInventory(keyType).keyAmount -= keyCost;
    }

    public void IncreaseKeyAmount(KeyType keyType, int pickedKey)
    {
        GetKeyInventory(keyType).keyAmount += pickedKey;
    }

    public void ShowKeyImage(KeyType keyType)
    {
        if(GetKeyInventory(keyType).keyImage == null) return;
        GetKeyInventory(keyType).keyImage.SetActive(true);
    }

    public void HideKeyImage(KeyType keyType)
    {
        if(GetKeyInventory(keyType).keyImage == null) return;
        GetKeyInventory(keyType).keyImage.SetActive(false);
    }

    private KeyInventory GetKeyInventory(KeyType keyType)
    {
        foreach(KeyInventory inventory in keys)
        {
            if(inventory.keyType == keyType)
            {
                return inventory;
            }
        }
        return null;
    }
}
