using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private float cd = 0.2f;
    private float flag = 1;
    private void Update()
    {
        transform.localScale = new Vector3(1.2f + flag * cd, 1.2f + flag * cd, 0);
        cd -= Time.deltaTime*0.5f;
        if(cd <= 0)
        {
            cd = 0.2f;
            flag = -1;
        }    
    }
    
}
