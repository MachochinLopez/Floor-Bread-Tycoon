using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Mejora", order = 1)]
public class Mejora : ScriptableObject
{
	public string description;
	public Sprite icon;

	public float initialIncrement;
	public int initialPrice;

	public float incrementalFactor;
	public string specialIncrement;

	public int incrementalAspect;
	public int costType;
}
