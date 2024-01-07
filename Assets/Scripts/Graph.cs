using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(2, 10)]
    int range = 2; // if range is 3 then it will be x:[-3; -3]

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    Transform[] points;

    void Awake()
    {
        float step = (float)range / resolution;
        Vector3 position = Vector3.zero;
        Vector3 Scale = Vector3.one * step;

        points = new Transform[resolution];

        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i] = Instantiate(pointPrefab);

            position.x = (i + 0.5f) * step - ((float)range / 2f);
            //position.y = position.x * position.x * position.x;

            point.localPosition = position;
            point.localScale = Scale;

            point.SetParent(transform, false);
        }
    }
    void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x - time));
            point.localPosition = position;
        }
    }
}
