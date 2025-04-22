using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public abstract class Buff<T> : IBuff
{
    public List<DataEffect<T>> dataEffects;
    public List<SpecialEffect<T>> specialEffects;
    public Buff()
    {
        dataEffects = new List<DataEffect<T>>();
        specialEffects = new List<SpecialEffect<T>>();
    }
    public Buff(List<Effect<T>> effects)
    {
        foreach (var effect in effects)
        {
            if (effect is DataEffect<T> dataEffect)
            {
                dataEffects.Add(dataEffect);
            }
            else if (effect is SpecialEffect<T> specialEffect)
            {
                specialEffects.Add(specialEffect);
            }
        }

    }

    public void Apply()
    {

    }

    public void Cancel()
    {

    }
}
