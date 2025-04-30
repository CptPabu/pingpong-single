using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Factories.Interfaces
{
    public interface IFactory<TInput, TReturn>
    {
        public TReturn Build(TInput input);
    }
}
