using System;
using System.Numerics;
using UnityEngine;

[System.Serializable]
public abstract class Generator
{
    protected int BatchSize;

    public Generator()
    {
        BatchSize = (int)(1 / Time.fixedDeltaTime);
    }

    protected BigInteger number = 1;
    protected float timer = 0;
    protected BigInteger remainder = 0;
    public abstract void Generate();
    protected void Generate(Action<BigInteger> generateAction)
    {
        float requiredTime = (1 / (float)number);
        if (requiredTime <= Time.fixedDeltaTime)
        {
            BigInteger quotient = BigInteger.DivRem(number + remainder, BatchSize, out remainder);
            generateAction(quotient);
        }
        else
        {
            timer += Time.fixedDeltaTime;
            while (timer > requiredTime)
            {
                timer = timer - requiredTime;
                generateAction(1);
            }
        }
    }
    public void IncreaseNumber(BigInteger _number)
    {
        number += _number;
    }
}

[System.Serializable]
public class NumberGenerator : Generator
{
    public override void Generate()
    {
        base.Generate(GameManager.Instance.IncreaseNumber);
    }
}

[System.Serializable]
public class NumberGenerator2 : Generator
{
    public override void Generate()
    {
        base.Generate(GameManager.Instance.IncreaseNumberGenerators);
    }
}