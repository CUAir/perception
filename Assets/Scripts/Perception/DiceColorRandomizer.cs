using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Perception.Randomization.Parameters;

[Serializable]
[AddRandomizerMenu("Perception/Dice Color Randomizer")]
public class DiceColorRandomizer : Randomizer
{
    public Material diceMaterial;
    public Material dipMaterial;

    public ColorRgbParameter color;
    public ColorRgbCategoricalParameter dipColor;

    protected override void OnIterationStart()
    {
        diceMaterial.color = color.Sample();
        dipMaterial.color = dipColor.Sample();

    }
}
