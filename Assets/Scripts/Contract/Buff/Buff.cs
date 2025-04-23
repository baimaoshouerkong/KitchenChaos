using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public enum BuffType
{
    DataEffect,
    SpecialEffect,
    DataAndSpecialEffect
}

/// <summary>
/// 对于一个buff来说他是对于某一个物体的数值上的影响，或者效果上的影响
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Buff<T> : IBuff
{
    public DataEffect<T> dataEffect = null;
    public SpecialEffect<T> specialEffect = null;

    public BuffType buffType;
    public Buff(BuffType buffType, DataEffect<T> dataEffect = null, SpecialEffect<T> specialEffect = null)
    {
        this.buffType = buffType;
        if (dataEffect != null)
            this.dataEffect = dataEffect;
        if (specialEffect != null)
            this.specialEffect = specialEffect;
    }


    public virtual void Apply()
    {

    }

    public virtual void Cancel()
    {

    }
}
