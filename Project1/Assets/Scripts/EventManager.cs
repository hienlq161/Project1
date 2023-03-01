using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour{
    public delegate void StartButton();
    public static event StartButton StartSequence;

    public void PressStartButton() {
        if (StartSequence == null) {
            return;
        }
        StartSequence();
    }
}
