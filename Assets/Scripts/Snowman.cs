using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Snowman : MonoBehaviour
{
    public event Action Died;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Died != null)
                Died();
        }
    }
}
