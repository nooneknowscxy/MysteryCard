using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

	public List<Card> cardLists;
	public static CardManager Instance {get; set;}
	private void Awake() {
		Instance = this;
	}

	public void GetCardsDependsCondition(BaseCondition condition){
		
	}

	public void RefreshCard(){
		
	}
}
