using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

namespace GamblersParadise
{
	public class YarnVariableBridge : VariableStorageBehaviour
	{
		public override Value GetValue(string variableName)
		{
			variableName = variableName.Substring(1);
			switch (variableName)
			{
				case "tokens": return new Value(GameState.Instance.SoulTokens);
				default: return Value.NULL;
			}
		}

		public override void ResetToDefaults()
		{
		}

		public override void SetValue(string variableName, Value value)
		{
		}
	}
}