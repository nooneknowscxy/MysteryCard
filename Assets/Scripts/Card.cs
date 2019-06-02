using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void ActionResults();
public class Card{
	public BaseCondition cardConditions;
	public int weight;
	public bool isTimeLimited;
	public int speakerID;
	public string speakerContent;
	public event ActionResults results;

	///<summary>
	///<param name="w">卡牌权重</param>
	///<param name="who">卡牌诉说者ID</param>
	///<param name="content">卡牌诉说内容</param>
	///<param name="timeLimited">是否有倒计时</param>
	///<param name="final">操作后的结果</param>
	///</summary>
	public Card(int w, int who, string content, bool timeLimited = false, ActionResults final = null){
		weight = w;
		speakerID = who;
		speakerContent = content;
		isTimeLimited = timeLimited;
		results = final;
	}
}

public class BaseCondition{
	public Dictionary<string, int> conditions;
	public BaseCondition(){
		conditions = new Dictionary<string, int>();
	}
}