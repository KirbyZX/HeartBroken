using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    public int health;
    public int experience;
    public int defence;
    public int attack;

	// Use this for initialization
	void Awake ()
    {
        if(gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
	}

    // Saving data to a file
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.health = health;
        data.experience = experience;
        data.defence = defence;
        data.attack = attack;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            experience = data.experience;
            defence = data.defence;
            attack = data.attack;
        }
    }
}

// Player data class
[Serializable]
class PlayerData
{
    public int health;
    public int experience;
    public int defence;
    public int attack;
}