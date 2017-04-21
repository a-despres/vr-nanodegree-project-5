using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

	public Text title;

	public void Set (Icon subject) {
		title.text = subject.title;
	}
}
