using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public Renderer renderer;
    public Color unselectedColor;
    public Color selectedColor;
    public Color hoverColor;
    public LayerMask movementLayerMask;
    public bool selected = false;
    public bool hover = false;
    CharacterController cc;
    float speed = 5;
    float destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selected && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                destination = hit.point;
            }
        }
        float distance = Vector3.Distance(transform.position, destination);
        if (distance > 0.1f)
        {
            transform.LookAt(destination);
                cc.Move(transform.forward * speed * Time.deltaTime);
        }
    }

    private void OnMouseOver()
    {
        hover = true;
        updateColor;
    }
    void OnMouseDown()
    {
        hover = true;
        updateColor; 
        }
    private void OnMouseExit()
    {
        //Change back to regular color
        renderer.material.color = unselectedColor;
    }
    public void updateColor()
    {
        if (selected)
        {
            renderer.material.color = selectedColor;
        }
        else
        {
            if (hoverColor)
            {
                renderer.material.color = hoverColor;
            }
            else
            {
                renderer.material.color = unselectedColor;
            }
        }
    }
}
