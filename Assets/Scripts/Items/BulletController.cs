using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public LayerMask colliderMask;
    public ParticleSystem explosionParticles;

    public float time_Life = 2f;
    public float maxDamade = 50f;
    public float explosionForce = 1000f;
    public float explosionRadius = 5f;   

	// Use this for initialization
	void Start () {
        Destroy(gameObject, time_Life);
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, colliderMask);

            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

                if (!targetRigidbody)
                    continue;

                targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                //targetRigidbody.GetComponent<HealthController>().AddDamage(maxDamade);
            }       

        explosionParticles.transform.parent = null;
        explosionParticles.Play();

        Destroy(explosionParticles, explosionParticles.duration);
        Destroy(gameObject);
    }

    private float calculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = transform.position - targetPosition;

        float explosionDistance = explosionToTarget.magnitude;

        float ratioDamage = (explosionRadius - explosionDistance) / explosionRadius;

        float damage = ratioDamage * maxDamade;

        damage = Mathf.Max(0f, damage);

        return damage;
    }
}
