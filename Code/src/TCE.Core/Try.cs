using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCE.Core
{
    public struct Try<TFail, TSuccess>
    {
        internal TFail Fail { get; }
        internal TSuccess Success { get; }
        public bool IsFail { get; }
        public bool IsSuccess => !IsFail;

        public Try(TFail fail)
        {
            Fail = fail;
            Success = default(TSuccess);
            IsFail = true;
        }

        public Try(TSuccess success)
        {
            Fail = default(TFail);
            Success = success;
            IsFail = false;
        }

        public TResult Result<TContext, TResult>(TContext context, Func<TContext, TSuccess, TResult> success, Func<TContext, TFail, TResult> fail)
            => this.IsFail ? fail(context, this.Fail) : success(context, this.Success);

        public static implicit operator Try<TFail, TSuccess>(TFail fail)
            => new Try<TFail, TSuccess>(fail);

        public static implicit operator Try<TFail, TSuccess>(TSuccess success)
            => new Try<TFail, TSuccess>(success);
    }
}
