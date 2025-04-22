using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IEffect
{
    // 生效Buff
    public void Apply();
    // 取消生效
    public void Cancel();
}
