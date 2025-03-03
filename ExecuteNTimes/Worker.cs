namespace Codewars.ExecuteNTimes;

using System;
using System.Threading;
using System.Threading.Tasks;

public class Worker
{
    public void Execute(Action a, int nTimes)
    {
        Task[] tasks = new Task[nTimes];

        for (int i = 0; i < nTimes; i++)
        {
            tasks[i] = Task.Run(a);
        }
        
        Task.WaitAll(tasks);
    }
}