using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    GameObject target;
    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, target.transform.position.z);
    }
}
