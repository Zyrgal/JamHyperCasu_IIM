using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class TestScriptAdds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowAdd()
    {
        Advertisement.Load("Rewarded_Android");
        Advertisement.Show("Rewarded_Android");
    }
}
