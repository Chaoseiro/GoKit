using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnchorPositionTweenTest : MonoBehaviour {

	public RectTransform _rectTransform;
	public float _speed = 2;

	GoTween _tween;

	// Use this for initialization
	void Start () {
		AnchoredPositionTweenProperty aptp = new AnchoredPositionTweenProperty(new Vector2(Screen.width, 0));
		GoTweenConfig config = new GoTweenConfig();
		config.addTweenProperty(aptp);
		
		_tween = new GoTween(_rectTransform, _speed, config);
		_tween.autoRemoveOnComplete = false;
		_tween.pause();
		Go.addTween(_tween);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			_tween.playBackwards();
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			_tween.playForward();
		}
	}
}
