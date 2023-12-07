using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReferencePayingButtonManager", menuName = "ScriptableObjects/ReferencePayingButtonManager", order = 1)]
public class ReferencePayingButtonManager : Reference<ReferencePayingButtonManager>
{
    public PayingButtonManager payingButtonManager;
}
