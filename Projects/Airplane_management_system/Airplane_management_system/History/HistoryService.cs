using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane_management_system.History
{
    // SERVICE LAYER 
    public class HistoryService
    {
        public HistoryRepository _historyRepo;

        public HistoryService(HistoryRepository hr)
        {
            _historyRepo = hr;
        }

        // CREATE: Add history
        public void LogAction(string action)
        {
            _historyRepo.SaveAction(action);
        }

        // READ: Get history
        public List<HistoryModel> GetHistory()
        {
            return _historyRepo.LoadData();
        }

    }
}
