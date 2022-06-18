using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Update", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("セット");
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
}
