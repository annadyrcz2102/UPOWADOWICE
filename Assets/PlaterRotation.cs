using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterRotation : MonoBehaviour
{
    public float rotationSpeed = 5f;

    void Update()
    {
        // Pobierz pozycj� myszy w przestrzeni ekranu
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Oblicz wektor kierunku od gracza do pozycji myszy na ekranie
        Vector3 directionToMouse = Camera.main.ScreenToWorldPoint(mouseScreenPosition) - transform.position;
        directionToMouse.y = 0f; // Zablokuj obr�t w osi Y

        // Oblicz docelowy k�t obrotu gracza
        Quaternion targetRotation = Quaternion.LookRotation(directionToMouse);

        // Obr�� gracza p�ynnie w kierunku myszy
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

