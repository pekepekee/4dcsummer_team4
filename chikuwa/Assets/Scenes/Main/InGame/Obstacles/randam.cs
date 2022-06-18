using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randam : MonoBehaviour
{
    public GameObject[] Meteo;
    private int number;
    private int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Make", 2f);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Make()
    {
        Vector3 randomPos = Vector3.zero;
        randomPos.y = Random.Range(-5, 5);

        number = Random.Range(0, Meteo.Length);
        Instantiate(Meteo[number], transform.position + randomPos, transform.rotation);
        if (count >= 0 && count <= 10)
        { Invoke("Make", 2.5f);
        }
        if(count >=11 && count <=23)
        {
          Invoke("Make", 2.25f);
         }
        if (count >= 24 && count<=39)
        {
            Invoke("Make", 2f);
        }
        if (count >= 40 && count <= 57)
        {
            Invoke("Make", 1.75f);
        }
        if (count >= 58 && count <= 78)
        {
            Invoke("Make", 1.5f);
        }
        if (count >= 58 && count <= 78)
        {
            Invoke("Make", 1.25f);
        }
        count++;
        
    }
}
