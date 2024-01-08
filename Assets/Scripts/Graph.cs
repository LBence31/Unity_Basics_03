using UnityEngine;
using UnityEngine.UIElements;

public class Graph : MonoBehaviour
{
	[SerializeField]
	Transform pointPrefab;

	[SerializeField, Range(2, 10)]
	int range = 2; // if [0-(range/2); 0+(range/2)]

	[SerializeField, Range(10, 100)]
	int resolution = 10;

	[SerializeField]
	FunctionLibrary.FunctionName function;

	Transform[] points;

	void Awake()
	{
		float step = (float)range / resolution;
		Vector3 position = Vector3.zero;
		Vector3 Scale = Vector3.one * step;

		points = new Transform[resolution * resolution];

		for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
		{
			if (x == resolution)
			{
				x = 0;
				z++;
			}
			Transform point = points[i] = Instantiate(pointPrefab);

			position.x = (x + 0.5f) * step - ((float)range / 2f);
			position.z = (z + 0.5f) * step - ((float)range / 2f);

			point.localPosition = position;
			point.localScale = Scale;
			point.SetParent(transform, false);
		}
	}
	void Update()
	{
		FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);  // Basically pointer function

		float time = Time.time;
		for (int i = 0; i < points.Length; i++)
		{
			Transform point = points[i];
			Vector3 position = point.localPosition;

			/*if (function == 0)
			{
				position.y = FunctionLibrary.Wave(position.x, time); //Mathf.Sin(Mathf.PI * (position.x - time));
			}
			else if (function == 1)
			{
				position.y = FunctionLibrary.MultiWave(position.x, time); //Mathf.Sin(Mathf.PI * (position.x - time));
			}
			else
			{
				position.y = FunctionLibrary.Ripple(position.x, time); //Mathf.Sin(Mathf.PI * (position.x - time));
			}*/

			position.y = f(position.x, position.z, time);
			point.localPosition = position;
		}
	}
}
