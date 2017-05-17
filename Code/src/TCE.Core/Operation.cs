using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCE.Core
{
    public struct Operation<TResult, TContext, TFail, TSuccess>
    {
        Func<TContext, TFail, TResult> Fail { get; }
        Try<TFail, TSuccess> Try { get; }
        TContext Context { get; }
        public Operation(TContext context, Try<TFail, TSuccess> @try, Func<TContext, TFail, TResult> fail)
        {
            Context = context;
            Fail = fail;
            Try = @try;
        }

        public TResult OnSuccess(Func<TContext, TSuccess, TResult> success)
            => Try.IsFail ? Fail(this.Context, this.Try.Fail) : success(this.Context, this.Try.Success);
    }
}
