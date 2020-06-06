﻿using Dialogues.Model;
using UnityEngine;

namespace Dialogues.View {

    public abstract class BaseDialogueViewer : MonoBehaviour {

        public ITextWriter TextWriter { get; set; }
        public DialogueAnimator DialogueAnimator { get; set; }

        public virtual void ConfigureViewer () {

            TextWriter = GetComponent<ITextWriter> ();
            DialogueAnimator = GetComponent<DialogueAnimator> ();
        }

        public virtual void ConfigureDialogue (Dialogue dialogue) { }
    }
}