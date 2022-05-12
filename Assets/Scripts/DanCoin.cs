using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanCoin : MonoBehaviour
{
    public int Speed2 = 4;
    private void Update()
    {
      
        transform.position += Vector3.left * Speed2 * Time.deltaTime;
    }
    
}
