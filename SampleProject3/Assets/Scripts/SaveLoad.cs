using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class SaveLoad : MonoBehaviour {

	public static SaveLoad Instance{ set; get; }

	public Text logText;

	public UnityEvent myEvent;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
	}

	[Serializable]
	public class SaveData
	{
//		public List<int> ID = new List<int>();
//		public List<int> Amounts = new List<int>();
		public int extra = 0;
		public float highScore = 0;
	}

	public void Save()
	{
		SaveData saveData = new SaveData();
		saveData.extra = 99;
		saveData.highScore = 40;
		//Convert to Json
		string jsonData = JsonUtility.ToJson(saveData);

		//Cryptor.Encrypt (jsonData);
		//Save Json string
		PlayerPrefs.SetString("MySave", Cryptor.Encrypt (jsonData));
		PlayerPrefs.Save();
	}

	public void Load()
	{
		//Load saved Json
		string jsonData = PlayerPrefs.GetString("MySave");
		//Convert to Class
		SaveData loadedData = JsonUtility.FromJson<SaveData>(Cryptor.Decrypt(jsonData));

		
		logText.text = loadedData.highScore.ToString(); 
	}
}
