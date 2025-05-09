using System;
using System.Collections.Generic;
using System.Text;

namespace JBAPI.API.Features.Interface
{
    public interface IWapper<T>
    {
        public T Base { get; }
    }
}
