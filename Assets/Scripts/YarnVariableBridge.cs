using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

namespace GameJam
{
	public class YarnVariableBridge : VariableStorageBehaviour
	{
		private readonly Dictionary<string, Value> dict = new Dictionary<string, Value>();

		public override Value GetValue(string variableName)
		{
			switch (variableName.Substring(1))
			{
				case "tokens": return new Value(GameState.Instance.SoulTokens);
				case "wasScarlet": return new Value(GameState.Instance.LastRollWasScarlet);
			}

			if (dict.TryGetValue(variableName, out Value value))
			{
				return value;
			}
			else
			{
				return Value.NULL;
			}
		}

		public override void ResetToDefaults()
		{
		}

		public override void SetValue(string variableName, Value value)
		{
			dict[variableName] = value;
		}
	}
}