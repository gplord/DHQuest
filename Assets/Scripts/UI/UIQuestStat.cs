using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIQuestStat : MonoBehaviour {

	public Image _icon;
	public Text _stat;

	public void Setup(Image icon, string stat) {
		_icon = icon;
		_stat.text = stat;
	}

}
