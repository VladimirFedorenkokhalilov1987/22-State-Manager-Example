using UnityEngine;
using System.Collections;

public class TestManager : MonoBehaviour
{
	private int _stateIndex;

	void OnGUI () 
	{
		if (GUI.Button (new Rect (10, 100, 100, 50), "<<")) 
		{
			if (_stateIndex == 0)
				_stateIndex = 6;
			
			StateManager.Instance.StateChanged ((StatesManager.Data.States)(--_stateIndex));
		}

		if (GUI.Button (new Rect (10, 10, 100, 50), ">>")) 
		{
			if (_stateIndex == 5)
				_stateIndex = -1;
		
			StateManager.Instance.StateChanged ((StatesManager.Data.States)(++_stateIndex));
		}
	}
}
