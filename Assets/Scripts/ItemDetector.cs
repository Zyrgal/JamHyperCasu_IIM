using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public InputPlayer player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BoostItem"))
        {
            other.gameObject.SetActive(false);
            player.GetComponent<InputPlayer>().Speed *= 1.3f;
        }
    }
}
