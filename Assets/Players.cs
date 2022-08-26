using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Players : MonoBehaviour
{
    protected Vector3 start_pos;
    protected List<GameObject> primitives;
    [SerializeField] protected PrimitiveType primitive = PrimitiveType.Cylinder;
    [SerializeField] protected float _speed = 1f;
    [SerializeField] protected float expectation_time = 1f;

    protected List<Vector3> _way = new List<Vector3>();
    void Awake()
    {
        start_pos = transform.position;
        SwitchWay();
    }
    void OnEnable()
    {
        StartCoroutine(Move());
    }
    void Update()
    {
        SwitchWay();
    }
    protected abstract void SwitchWay();

    protected void Clear()
    {
        foreach (var obj in primitives)
            Destroy(obj.gameObject);
        primitives.Clear();
    }
    protected IEnumerator Move()
    {
        int i = 0;
        while (true)
        {
            if (i >= _way.Count)
                i = 0;
            transform.position = Vector3.MoveTowards(transform.position, _way[i], _speed);
            if (transform.position == _way[i])
            {
                i++;
                var temp = GameObject.CreatePrimitive(primitive);
                temp.transform.localScale *= 0.3f;
                temp.transform.position = transform.position;
                primitives.Add(temp);
            }
            yield return new WaitForSeconds(expectation_time);
        }
    }
}
