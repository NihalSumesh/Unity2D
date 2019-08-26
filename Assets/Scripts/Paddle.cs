using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenUnitsInWidth = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 16f;


    void Update()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenUnitsInWidth;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = paddlePos;
    }
}
