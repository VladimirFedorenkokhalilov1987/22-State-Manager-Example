using UnityEngine;
using System.Collections;
using StatesManager.Data;

public class UIstateComponent : MonoBehaviour
{
	public States[] _activeStates; 

	void Start () 
	{
		gameObject.SetActive (false);

		if (StateManager.Instance != null) 
		{
			StateManager.Instance.OnStateChanged+= StateManager_Instance_OnStateChanged;
		}
		else
		{
			print ("State Manager is NULL");
		}
	}

	void OnDestroy () 
	{
		if (StateManager.Instance != null)
		{
			StateManager.Instance.OnStateChanged-= StateManager_Instance_OnStateChanged;
		}
	}

	void StateManager_Instance_OnStateChanged (States current, States arg2)
	{
		foreach (var item in _activeStates) 
		{
			if (item == current) 
			{
				gameObject.SetActive (true);
				return;
			}
		}
		gameObject.SetActive (false);
	}
}