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
    }

    public int GetCurrentKeyAmount(KeyType keyType)
    {
        return GetKeyInventory(keyType).keyAmount;
    }

    public void ReduceKeyAmount(KeyType keyType)
    {
        GetKeyInventory(keyType).keyAmount--;
    }

    public void IncreaseKeyAmount(KeyType keyType, int pickedKey)
    {
        GetKeyInventory(keyType).keyAmount += pickedKey;
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
