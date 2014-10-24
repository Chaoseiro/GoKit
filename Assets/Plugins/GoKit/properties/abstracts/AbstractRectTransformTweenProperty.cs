using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public abstract class AbstractRectTransformTweenProperty : AbstractTweenProperty
{
	protected RectTransform _target;

	protected Vector2 _originalEndValue;
	protected Vector2 _startValue;
	protected Vector2 _endValue;
	protected Vector2 _diffValue;

	public AbstractRectTransformTweenProperty()
	{}


	public AbstractRectTransformTweenProperty(Vector2 endValue, bool isRelative = false)
		: base(isRelative)
	{
		_originalEndValue = endValue;
	}


	public override bool validateTarget( object target )
	{
		return target is RectTransform;
	}
	
	
	public override void prepareForUse()
	{
		if( _isRelative && !_ownerTween.isFrom )
			_diffValue = _endValue;
		else
			_diffValue = _endValue - _startValue;
	}
	
	
	public void resetWithNewEndValue( Vector2 endValue )
	{
		_originalEndValue = endValue;
		prepareForUse();
	}
}

