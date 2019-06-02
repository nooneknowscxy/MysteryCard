using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameStatus currentStatus;
	public int currentTurn, totalTurns;
	public float turnDuration;
	public static GameManager Instance {get; set;}
	void Awake()
	{
		Instance = this;
	}
}

public enum GameStatus
{
	FreeTime,
	ReadCard,
	Action,
	AfterAction
}
