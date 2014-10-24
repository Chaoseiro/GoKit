using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnchoredPositionTweenProperty : AbstractRectTransformTweenProperty
{
	public AnchoredPositionTweenProperty(Vector2 endValue, bool isRelative = false)
		: base(endValue, isRelative)
	{
	}

	public override void prepareForUse()
	{
		_target = _ownerTween.target as RectTransform;

		_endValue = _originalEndValue;

		// if this is a from tween we need to swap the start and end values
		if (_ownerTween.isFrom)
		{
			
			if (_isRelative)
				_startValue = _target.anchoredPosition + _endValue;
			else
				_startValue = _endValue;

			_endValue = _target.position;
			
		}
		else
		{
			_startValue = _target.anchoredPosition;
		}

		base.prepareForUse();
	}

	public override void tick(float totalElapsedTime)
	{
		var easedTime = _easeFunction(totalElapsedTime, 0, 1, _ownerTween.duration);
		var vec = GoTweenUtils.unclampedVector2Lerp(_startValue, _diffValue, easedTime);

		_target.anchoredPosition = vec;
	}
}

