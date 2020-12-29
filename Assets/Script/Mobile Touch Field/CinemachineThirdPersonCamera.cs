using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineThirdPersonCamera : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook freeLook;
    [SerializeField] TouchFields touchPad;

    private void Update() {
        // Set the value in Cinemachine Free Look to the TouchDistance value in TouchFields.cs
        freeLook.m_XAxis.m_InputAxisValue = touchPad.TouchDistance.x;
        freeLook.m_YAxis.m_InputAxisValue = touchPad.TouchDistance.y;
    }
}
