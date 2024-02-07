using System;
using System.Collections.Generic;
using System.Threading;

namespace BGGallery.Utils
{
    public class DelayedExecutor
    {
        private static readonly Dictionary<string, Timer> timers = new Dictionary<string, Timer>();
        private static readonly Dictionary<string, CancellationTokenSource> cancellationTokens = new Dictionary<string, CancellationTokenSource>();

        public static void Trigger(string eventName, float delayTime, Action action)
        {
            // 如果存在同名事件，先取消计时器
            if (timers.ContainsKey(eventName))
            {
                cancellationTokens[eventName].Cancel();
                timers[eventName].Dispose();
            }

            if(delayTime == 0)
            {//立刻执行
                action.Invoke();
                return;
            }

            // 创建新的计时器和取消令牌
            var cancellationTokenSource = new CancellationTokenSource();

            SynchronizationContext context = SynchronizationContext.Current;
            var timer = new Timer(_ => context.Post(a => ExecuteAction(eventName,  action), null), null, (int)(delayTime * 1000), Timeout.Infinite);

            // 将计时器和取消令牌存储到字典中
            timers[eventName] = timer;
            cancellationTokens[eventName] = cancellationTokenSource;
        }

        private static void ExecuteAction(string eventName, Action action)
        {
            try
            {
                // 执行操作
                action.Invoke();
            }
            finally
            {
                // 取消计时器
                cancellationTokens[eventName].Cancel();
            }
        }
    }
}
