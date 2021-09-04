using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] GameObject linePrefab;
    Transform line;
    [SerializeField] FireButton fireButton;
    Vector3 startPos;

    bool drawing;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !fireButton.CheckButton())
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            line = Instantiate(linePrefab, Vector3.zero, Quaternion.identity).transform;
            Vector3 pos = new Vector3(startPos.x, startPos.y, .5f);
            startPos = pos;

            drawing = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            drawing = false;
        }
        if (drawing)
        {
            InDrawing();
        }
    }
    void InDrawing()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        PositionLine(startPos, new Vector3(pos.x, pos.y, 0.5f));
    }
    void PositionLine(Vector3 p1, Vector3 p2)
    {
        line.position = (p1 + p2) / 2;
        Quaternion XLookRotation = Quaternion.LookRotation((p1 - p2).normalized, transform.up) * Quaternion.Euler(new Vector3(0, 90, 0));
        line.rotation = XLookRotation;
        Vector3 scale  = line.localScale;
        scale.x = (p1 - p2).magnitude;
        line.localScale = scale;
    }
}
