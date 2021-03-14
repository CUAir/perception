using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;

[Serializable]
[AddRandomizerMenu("Perception/Camera Randomizer")]
public class CameraRandomizer : Randomizer
{
    public FloatParameter cameraXRotation;
    public FloatParameter cameraDistance;
    public Camera mainCamera;

    protected override void OnIterationStart()
    {
        var elevation = cameraXRotation.Sample();
        var distance = cameraDistance.Sample();

        var z = -distance * Mathf.Cos(elevation * Mathf.PI / 180);
        var y = distance * Mathf.Sin(elevation * Mathf.PI / 180);

        mainCamera.transform.rotation = Quaternion.Euler(elevation, 0f, 0f);
        mainCamera.transform.position = new Vector3(0f, y, z);
    }

}
