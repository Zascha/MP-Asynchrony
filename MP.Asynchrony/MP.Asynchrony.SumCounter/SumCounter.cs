using System.Threading;
using System.Threading.Tasks;

namespace MP.Asynchrony.Counter
{
    public class SumCounter
    {
        private CancellationTokenSource source;

        public async Task<long> CalculateSumAsync(long startValue, long limitValue)
        {
            if (source != null)
            {
                source.Cancel();
            }

            source = new CancellationTokenSource();

            return await Task.Run(() => { return CalculateSum(startValue, limitValue); }, source.Token);
        }

        #region Private methods

        private long CalculateSum(long startValue, long limitValue)
        {
            long result = 0;

            checked
            {
                for (long i = startValue; i <= limitValue; i++)
                {
                    result += i;
                }
            }

            return result;
        }

        #endregion
    }
}
