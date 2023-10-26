using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TriggerFX : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] GameObject parent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TriggerBoost")
        {
            ParticleSystem ps = Instantiate(particle, new Vector3(transform.position.x, transform.position.y, transform.position.z),Quaternion.identity);
            ps.Play();
        }
    }
}
