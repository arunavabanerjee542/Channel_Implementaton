using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyChannel
{
    class ChannelData<T>
    {
        private ConcurrentQueue<T> _q = new ConcurrentQueue<T>();

        private SemaphoreSlim _s = new SemaphoreSlim(0);


        public void Write(T item)
        {
            _q.Enqueue(item);
            Console.WriteLine("Producer stores " + item);
            _s.Release();

        }


        public async Task<T> Read()
        {
            await _s.WaitAsync();

            _q.TryDequeue(out T i);
            Console.WriteLine("Consumer reads " + i);

            return i;


        }





    }
}
