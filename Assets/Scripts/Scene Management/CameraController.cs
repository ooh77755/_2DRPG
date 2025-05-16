using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineVirtualCamera vCam;

    PlayerController pC;

    private void Start()
    {
        pC = FindObjectOfType<PlayerController>();
    }

    public void SetPlayerCameraFollow()
    {
        vCam = FindObjectOfType<CinemachineVirtualCamera>();
        vCam.Follow = pC.transform;
    }
}
