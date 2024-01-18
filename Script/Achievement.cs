using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Achievement
{
    public string achievementName;
    public bool achieved;

    public Achievement(string inputName) {
        achievementName = inputName;
        achieved = false;
    }

    public void SetAchieved() {
        achieved = true;
    }
}
