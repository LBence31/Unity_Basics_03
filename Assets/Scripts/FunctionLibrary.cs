using UnityEngine;
using static UnityEngine.Mathf; // replaces Matf.Sin to Sin and Matf.PI to PI. Static to only use the static functions and constants

public static class FunctionLibrary
{
	public static float Wave(float x, float t)
	{
		return Sin(PI * (x + t));
	}

	public static float MultiWave(float x, float t)
	{
		float y = Sin(PI * (x + 0.5f * t));
		y += 0.5f * Sin(2f * PI * (x + t));
		return y * (2f / 3f);
	}

	public static float Ripple(float x, float t)
	{
		float d = Abs(x);
		float y = Sin(4f * PI * d);
		return y / (1f + 10f * d);
	}

	// Pointer function
	public delegate float Function(float x, float t);

	public enum FunctionName { Wave, MultiWave, Ripple }
	static Function[] functions = { Wave, MultiWave, Ripple };

	public static Function GetFunction(FunctionName name)
	{
		return functions[(int)name];
		/*if (index == 0)
		{
			return Wave;
		}
		else if (index == 1)
		{
			return MultiWave;
		}
		else
		{
			return Ripple;
		}*/
	}

}