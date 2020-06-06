﻿using System;
using Dialogues.Controller;
using Dialogues.View;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dialogues {

    public class DialogueManager : MonoBehaviour {

        public static DialogueManager Instance {
            get { return _instance; }
            private set { }
        }
        private static DialogueManager _instance;
        private const string DIALOGUE_SCENE_NAME = "BigCharDialogue";

        [RuntimeInitializeOnLoadMethod (RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void InstantiateManager () {

            GameObject manager = new GameObject ("DialogueManager");
            manager.AddComponent (typeof (DialogueManager));
            _instance = manager.GetComponent<DialogueManager> ();
            DontDestroyOnLoad (manager);
        }

        public void RunDialogue (Action<BaseDialogueViewer> callback) {

            SceneManager.LoadSceneAsync (DIALOGUE_SCENE_NAME, LoadSceneMode.Additive).completed += (operation) => {

                var dialogueViewer = FindObjectOfType<BaseDialogueViewer> ();
                dialogueViewer.ConfigureViewer ();

                callback?.Invoke (dialogueViewer);
            };
        }

        public void FinishDialogue (Action callback) {

            SceneManager.UnloadSceneAsync (DIALOGUE_SCENE_NAME).completed += (operation) => {

                callback?.Invoke ();
            };
        }
    }
}