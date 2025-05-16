using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineVirtualCamera vCam;

    public void SetPlayerCameraFollow()
    {
        vCam = FindObjectOfType<CinemachineVirtualCamera>();
        vCam.Follow = PlayerController.Instance.transform;
    }
}
