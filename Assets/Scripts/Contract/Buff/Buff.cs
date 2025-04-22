using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public abstract class Buff : IBuff
{
    public List<DataEffect> dataEffects;
    public List<SpecialEffect> specialEffects;
    public Buff()
    {
        dataEffects = new List<DataEffect>();
        specialEffects = new List<SpecialEffect>();
    }
    public Buff(List<Effect> effects)
    {
        foreach (var effect in effects)
        {
            if (effect is DataEffect dataEffect)
            {
                dataEffects.Add(dataEffect);
            }
            else if (effect is SpecialEffect specialEffect)
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
