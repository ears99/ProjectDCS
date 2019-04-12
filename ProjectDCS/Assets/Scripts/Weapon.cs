﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

using UnityStandardAssets.Characters.FirstPerson;

public enum ShootType {
    PROJECTILE,
    RAYCAST
}

public class Weapon : MonoBehaviour
{
    public ShootType shootType;
    public GameObject projectile;
    public Transform projectileSpawnpoint;
    public FirstPersonController fpc;
    public GameManager gm;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(gm.controllerId);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButton("Shoot")) {
            if (shootType == ShootType.PROJECTILE) {
                // Inst.
                Instantiate(projectile, projectileSpawnpoint.position, projectileSpawnpoint.rotation);
            } else {
                // Raycast
            }
        }
    }
}
