using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;

[Serializable]
[AddRandomizerMenu("Perception/Target Randomizer")]
public class TargetRandomizer : Randomizer

{
    public GameObjectParameter shapePrefabs;

    public GameObjectParameter alphaPrefabs;
    public FloatParameter scale;
    public Vector3Parameter rotation;

    public Vector3Parameter placementLocation;

    public MaterialParameter colorMaterials;

    private GameObject shapeInstance;
    private GameObject alphaInstance;

    protected override void OnIterationStart()
    {
        shapeInstance = GameObject.Instantiate(shapePrefabs.Sample());
        alphaInstance = GameObject.Instantiate(alphaPrefabs.Sample());
        alphaInstance.transform.parent = shapeInstance.transform;

        shapeInstance.transform.position = placementLocation.Sample();
        shapeInstance.transform.rotation = Quaternion.Euler(rotation.Sample());
        shapeInstance.transform.localScale = Vector3.one * scale.Sample();

        alphaInstance.transform.position = new Vector3(alphaInstance.transform.position.x, alphaInstance.transform.position.y + 0.1f, alphaInstance.transform.position.z);

        Material shapeMat = colorMaterials.Sample();
        Material alphaMat = colorMaterials.Sample();
        while (alphaMat.color == shapeMat.color)
        {
            alphaMat = colorMaterials.Sample();
        }

        shapeInstance.GetComponentsInChildren<MeshRenderer>()[0].material = shapeMat;
        alphaInstance.GetComponentsInChildren<MeshRenderer>()[0].material = alphaMat;

    }

    protected override void OnIterationEnd()
    {
        GameObject.Destroy(shapeInstance);
        GameObject.Destroy(alphaInstance);
    }

}
