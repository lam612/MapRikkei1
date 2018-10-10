using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Items : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject item = null;

    public bool isDefaultItem = false;
    public float value = 0f;
    public Typeitem typeitem;

    public virtual void Use()
    {
        Debug.Log("Use Item : " + name);
    }

    public enum Typeitem { bullet, gasoline}

}
