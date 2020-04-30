using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ActionExecution
{
    public class ActionExecution
    {
        private readonly ConcurrentQueue<string> _actionQueue;
        public ActionExecution()
        {
            _actionQueue = new ConcurrentQueue<string>();
        }

        public void StartProcessing()
        {
         
            while (!_actionQueue.IsEmpty)
            {
                ProcessNextAction();                
            }

        }

        public void AddAction(string singleTask)
        {
            _actionQueue.Enqueue(singleTask);
        }

        public async void ProcessNextAction()
        {
            _actionQueue.TryDequeue(out var currentAction);
            var syncAction = new Task(() => ProcessAction(currentAction));
            syncAction.RunSynchronously();
            await Task.Yield();

        }
        
        private static async void ProcessAction(string action)
        {
            Console.WriteLine(action);
            await Task.Yield();
        }

        public bool ActionsToBeProcessed()
        {
            return _actionQueue.Count > 0;
        }

    }
}
