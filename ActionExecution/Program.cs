using System.Linq;

namespace ActionExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            var actionExecution = new ActionExecution();

            foreach (var single in Enumerable.Range(1, 1000))
            {
                actionExecution.AddAction($"Action {single}");
            }

            actionExecution.StartProcessing();

            actionExecution.AddAction($"Action 1001");
            actionExecution.AddAction($"Action 1002");

            if(actionExecution.ActionsToBeProcessed())
            {actionExecution.StartProcessing();}
        }
    }
}
