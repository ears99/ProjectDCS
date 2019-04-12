﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

using UnityStandardAssets.Characters.FirstPerson;

public enum RespawnType {
    ATPLAYER, ATPOS
}

public class GameManager : MonoBehaviour
{
    public RespawnType respawnType;

    public static GameManager instance;
    public List<FirstPersonController> players = new List<FirstPersonController>();
    public GameObject playerPrefab;
    public int startingId = 0;
    public Vector3 respawnPos = new Vector3(0, 0, 0);
    public Quaternion respawnRot = new Quaternion(0, 0, 0, 0);

    void Awake() {
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        players.Add(FindObjectOfType<FirstPersonController>());
        players[0].controllerId = 0;
    }

    // Update is called once per frame
 

    public void AddPlayer(int id) {
       foreach(FirstPersonController p in players) {
            if (p.controllerId == id) return;
        }

        Debug.Log("Player Joined.");
        GameObject obj = new GameObject();
        switch (respawnType) {
            case RespawnType.ATPLAYER:
                obj = Instantiate(playerPrefab, transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
                break;
            case RespawnType.ATPOS:
                obj = Instantiate(playerPrefab, respawnPos, respawnRot);
                break;
            default:
                break;
        }
        FirstPersonController player = obj.GetComponent<FirstPersonController>();
        player.controllerId = id;
        players.Add(player);
        Debug.Log(players.Count + " players now.");

        if(players.Count == 2) {
            players[0].m_Camera.GetComponent<Camera>().rect = new Rect(0, .5f, 1, .5f);
            players[0].UICam.rect = new Rect(0, .5f, 1, .5f);
            players[1].m_Camera.GetComponent<Camera>().rect = new Rect(0, 0, 1, .5f);
            players[1].UICam.rect = new Rect(0, 0f, 1, .5f);
        } else if (players.Count == 3) {
            players[0].m_Camera.GetComponent<Camera>().rect = new Rect(0, .5f, 1, .5f);
            players[0].UICam.rect = new Rect(0, .5f, 1, .5f);
            players[1].m_Camera.GetComponent<Camera>().rect = new Rect(0, 0, .5f, .5f);
            players[1].UICam.rect = new Rect(0, 0, .5f, .5f);
            players[2].m_Camera.GetComponent<Camera>().rect = new Rect(.5f, 0, .5f, .5f);
            players[2].UICam.rect = new Rect(.5f, 0, .5f, .5f);
        } else if (players.Count == 4) {
            players[0].m_Camera.GetComponent<Camera>().rect = new Rect(0, .5f, .5f, .5f);
            players[0].UICam.rect = new Rect(0, .5f, .5f, .5f);
            players[1].m_Camera.GetComponent<Camera>().rect = new Rect(.5f, .5f, .5f, .5f);
            players[1].UICam.rect = new Rect(.5f, .5f, .5f, .5f);
            players[2].m_Camera.GetComponent<Camera>().rect = new Rect(0, 0, .5f, .5f);
            players[2].UICam.rect = new Rect(0, 0, .5f, .5f);
            players[3].m_Camera.GetComponent<Camera>().rect = new Rect(.5f, 0, .5f, .5f);
            players[3].UICam.rect = new Rect(.5f, 0, .5f, .5f);
        }
    }
}