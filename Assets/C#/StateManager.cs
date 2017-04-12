using UnityEngine;
using System.Collections;
using StatesManager.Data;
using System;

public class StateManager : MonoBehaviour
{
	
	#region EVENTS
	public event Action<States,States> OnStateChanged; // Action  -------- System

	private void OnStateChangedHandler (States newState, States previousState)
	{
		if (OnStateChanged != null)
			OnStateChanged (newState, previousState);
	}
	#endregion

	#region SINGLETONE PART
	private static StateManager _instance;

	public static StateManager Instance 
	{
		get 
		{
			return _instance;
		}
	}
	#endregion

	private States _currentState;
	private States _previousState;

	#region UNITY EVENTS
	void Awake ()
	{
		if (_instance == null) 
		{
			_instance = this;
			DontDestroyOnLoad (gameObject);
		
		}
		else 
		{
			DestroyImmediate (gameObject);
		}
	}

	private void OnGUI()
	{
		GUI.Box (new Rect (120, 10, 400, 50), "_currentState" + " is "+ _currentState);
		GUI.Box (new Rect (120, 100, 400, 50), "_previousState" +" is "+ _previousState);
	}
	#endregion

	public void StateChanged (States newState)
	{
		_previousState = _currentState;
		_currentState = newState;
		OnStateChangedHandler (_currentState, _previousState);
	}
}
