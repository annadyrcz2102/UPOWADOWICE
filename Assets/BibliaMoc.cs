using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibliaMoc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(Time.deltaTime*2, Time.deltaTime*2, 0);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
