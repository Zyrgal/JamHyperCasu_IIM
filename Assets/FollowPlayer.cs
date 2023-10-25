using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    GameObject target;

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, target.transform.position.z);
    }
}
