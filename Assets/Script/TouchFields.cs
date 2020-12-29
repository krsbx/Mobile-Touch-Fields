using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TouchFields : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    // PointerId will be used as an index of the current input that user give by touch input
    int PointerId = -1;
    // To Check User Dragging or not
    bool IsDragging = false;
    // To store all the needed data
    // TouchDistance will store the distance between previous finger positions to the latest finger positions
    // TouchPos will store the previous finger positions
    [HideInInspector] public Vector2 TouchDistance, TouchPos;
    
    private void Update() {
        // If user lift their fingers
        if(!IsDragging){
            TouchDistance = Vector2.zero; // Set the distances between touch to zero
            return;
        }

        // If there's an input from users
        //  First one will be used in mobile devices
        //  Second one will be used in the unity engine
        //    Used for prototyping
        if(PointerId >= 0 && PointerId < Input.touches.Length){
            // Count the distances between the the current finger positions with the finger first positions
            TouchDistance = Input.touches[PointerId].position - TouchPos;
            // Changes TouchPos to the newest finger positions
            TouchPos = Input.touches[PointerId].position;
        }else{
            // Count the distances between the current mouse positions with the mouse first positions
            TouchDistance = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - TouchPos;
            // Changes TouchPos to the newest mouse positions
            TouchPos = Input.mousePosition;
        }
    }

    public void OnPointerUp(PointerEventData data){
        IsDragging = false; // User lift their fingers
    }
    
    public void OnPointerDown(PointerEventData data){
        IsDragging = true; // User finger is moving
        PointerId = data.pointerId; // Set the current pointerId to PointerId
        TouchPos = data.position; // Set every user finger position to TouchPos
    }
}
