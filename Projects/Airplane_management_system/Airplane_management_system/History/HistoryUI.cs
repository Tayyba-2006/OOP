using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane_management_system.History
{
   // UI LAYER 
    public class HistoryUI
    {
        public HistoryService _historyService;

        public HistoryUI(HistoryService hs)
        {
            _historyService = hs;
        }

        // READ: SHOW HISTORY
        public void ShowHistory()
        {
            Console.Clear();

            Console.WriteLine("========== HISTORY ==========");

            List<HistoryModel> history =
                _historyService.GetHistory();

            if (history.Count == 0)
            {
                Console.WriteLine("No history available!");
            }
            else
            {
                for (int i = 0; i < history.Count; i++)
                {
                    Console.WriteLine(
                        (i + 1) + ". " + history[i].Action);
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
