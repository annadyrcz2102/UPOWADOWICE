using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterRotation : MonoBehaviour
{
    public float rotationSpeed = 5f;

    void Update()
    {
        // Pobierz pozycjê myszy w przestrzeni ekranu
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Oblicz wektor kierunku od gracza do pozycji myszy na ekranie
        Vector3 directionToMouse = Camera.main.ScreenToWorldPoint(mouseScreenPosition) - transform.position;
        directionToMouse.y = 0f; // Zablokuj obrót w osi Y

        // Oblicz docelowy k¹t obrotu gracza
        Quaternion targetRotation = Quaternion.LookRotation(directionToMouse);

        // Obróæ gracza p³ynnie w kierunku myszy
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

