using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target; // Obiekt, kt�ry chcemy �ledzi� (np. gracz)
    public float smoothSpeed = 0.125f; // Wsp�czynnik p�ynno�ci ruchu kamery

    public Vector3 offset; // Przesuni�cie kamery wzgl�dem obiektu �ledzonego

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target); // Ustawienie kamery, aby patrzy�a na obiekt �ledzony
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
