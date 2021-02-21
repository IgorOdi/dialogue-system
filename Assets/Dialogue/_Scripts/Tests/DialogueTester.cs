﻿using Dialogues.Controller.Core;
using Dialogues.Model.Core;
using UnityEngine;

public class DialogueTester : MonoBehaviour {

	public BasicDialogueAsset dialogueAsset;

	void Start() {

		FindObjectOfType<DialogueController> ().ShowDialogue (dialogueAsset);
	}

	void Update() {

		if (Input.GetKeyDown (KeyCode.Space)) {

			FindObjectOfType<DialogueController> ().ShowDialogue (dialogueAsset);
		}
	}

	public void CallA() {

		Debug.Log ("A");
	}

	public void CallB() {

		Debug.Log ("B");
	}
}