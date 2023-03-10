using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventManager : MonoBehaviour{

    [SerializeField] int numberOfBlackHole;

    [SerializeField] TextMeshProUGUI blackHoleNumberText;
    [SerializeField] GameObject blackHoleRadius;
    [SerializeField] Animator iconAnimation;
    [SerializeField] Button startSequenceButton;
    [SerializeField] Button spawnButton;
    

    public delegate void StartButton();
    public static event StartButton StartSequence;

    private void Start() {
        UpdateText(numberOfBlackHole);
    }
    public void SpawnBlackHole() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Instantiate(blackHoleRadius, mousePosition, Quaternion.identity);
        numberOfBlackHole--;
        UpdateText(numberOfBlackHole);

        if (numberOfBlackHole ==0) {
            if (spawnButton == null) return;
            spawnButton.interactable = false;
        }
    }

    public void PressStartButton() {
        if (numberOfBlackHole > 0) {
            if (iconAnimation == null) return;
            iconAnimation.SetTrigger("NotReady");
            return;
        }
        if (StartSequence == null) {
            return;
        }
        StartSequence();
        if (startSequenceButton == null) return;
        startSequenceButton.interactable = false;
    }
    private void UpdateText(int number) {
        if (blackHoleNumberText == null) return;
        blackHoleNumberText.text = "X" + number.ToString();
    }
}
