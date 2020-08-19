using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeSentence : MonoBehaviour
{

	//public Text nameText;
	public Text dialogueText;

	// Use this for initialization
	void Start()
	{
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		StopAllCoroutines();
		StartCoroutine(TypeSentenceX(dialogueText.text));
	}

	IEnumerator TypeSentenceX(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}
}
