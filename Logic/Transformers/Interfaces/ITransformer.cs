using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Transformers.Interfaces
{
    public interface ITransformer<TInput, TReturn>
    {
        public TReturn Transform(TInput input);
        public List<TReturn> Transform(IQueryable<TInput> input);
    }
}
