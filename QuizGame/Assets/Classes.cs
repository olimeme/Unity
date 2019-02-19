using System.Collections.Generic;

[System.Serializable]
public class Question
{
	public int id;
	public string name_ru;
	public bool right_answer;
}

[System.Serializable]
public class GameData{
	public List<Question> array;
}

