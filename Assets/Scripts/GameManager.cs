using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; } 
        set 
        {
            if (instance != null)
            {
                Destroy(value.gameObject);
                return;
            }
            instance = value;
        }
    }

    public ObservedValue<BigInteger> Number = new ObservedValue<BigInteger>();
    [SerializeReference] public List<Generator> Generators;
    public List<int> ints;

    private void Awake()
    {
        Instance = this;
        Number.Value = 0;
        Generators = new List<Generator>()
        {
            new NumberGenerator(),
            new NumberGenerator2()
        };
    }

    public void FixedUpdate()
    {
        foreach (Generator generator in Generators)
        {
            generator.Generate();
        }
    }

    public void IncreaseNumber()
    {
        Number.Value += 1;
    }

    public void IncreaseNumber(BigInteger number)
    {
        Number.Value += number;
    }

    public void IncreaseNumberGenerators()
    {
        NumberGenerator gen = Generators.FirstOrDefault(g => typeof(NumberGenerator) == g.GetType()) as NumberGenerator;
        print(gen);
        gen.IncreaseNumber(1);
    }

    public void IncreaseNumberGenerators(BigInteger number)
    {
        NumberGenerator gen = Generators.FirstOrDefault(g => typeof(NumberGenerator) == g.GetType()) as NumberGenerator;
        print(gen);
        gen.IncreaseNumber(number);
    }
}

public class ObservedValue<T>
{
    private event Action<T> OnChanged;

    private T _value;
    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            OnChanged?.Invoke(_value);
        }
    }

    public ObservedValue(T initialValue = default)
    {
        _value = initialValue;
    }

    public void AddListener(Action<T> action)
    {
        OnChanged += action;
        action(Value);
    }

    public static implicit operator T(ObservedValue<T> observed) => observed._value;
}

public class ObservedList<T> : IList<T>
{
    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}