using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerayobi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Coroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Coroutine()
    {
        Debug.Log("Start");

        yield return new WaitForSeconds(6f);

        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }

        yield break;
    }
}
