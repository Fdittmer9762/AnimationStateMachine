using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Spawner/Round")]
public class Round : ScriptableObject {

	public AnimationCurve curve;
	public AnimationCurve centerCV;

	[HideInInspector]public int WavesPerRound;
	private float SD, maxSD, Center, maxRounds = 100;

	[HideInInspector]public List<Wave> roundWaves = new List<Wave> ();


	public void CreateRound(Wave[] _waves, int _round){
		Debug.Log ("Creating Round");
		roundWaves.Clear();
		maxSD = Mathf.RoundToInt(_waves.Length / 8);
		SD = ((-.5f * maxSD) * Mathf.Cos((6.28f / maxRounds) * _round)) + (.5f * maxSD) +.5f;
		Center = _waves.Length * centerCV.Evaluate(_round/maxRounds);
		WavesPerRound = Mathf.RoundToInt (_round / (_waves.Length* .5f)) + 1;
		for (int i = 0; i < WavesPerRound; i++) {
			AddToList (_waves);
		}
	}

	public void AddToList(Wave[] _waves){
		float rndVal = (curve.Evaluate (Random.value) * (2*SD)) -SD;
		roundWaves.Add (_waves[Mathf.RoundToInt(Center + Mathf.Round(rndVal))]);
	}
}
