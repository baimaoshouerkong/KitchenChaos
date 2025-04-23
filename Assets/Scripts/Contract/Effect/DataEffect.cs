using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// 对于数据来说优先级先先对优先级的进行运算
// 最后固定值进行加减
// 中间百分比进行加减
// 先对于特殊值进行运算
// A * B + C  
public class DataEffect<T> : Effect<T>
{
    public float number;
    protected DataEffect(EffectPriority priority, EffectType effectType = EffectType.DataEffect) : base(priority, effectType)
    {
        
    }


    
}
