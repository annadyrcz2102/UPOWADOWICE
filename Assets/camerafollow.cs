using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target; // Obiekt, który chcemy œledziæ (np. gracz)
    public float smoothSpeed = 0.125f; // Wspó³czynnik p³ynnoœci ruchu kamery

    public Vector3 offset; // Przesuniêcie kamery wzglêdem obiektu œledzonego

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target); // Ustawienie kamery, aby patrzy³a na obiekt œledzony
        }
    }// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
