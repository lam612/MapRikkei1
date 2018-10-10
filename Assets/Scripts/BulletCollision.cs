using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

    public Items item;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("On Trigger " + other.name);
            //other.GetComponent<PlayerShooting>.Bullet = item.item;
            Destroy(gameObject);
        }
    }
}
