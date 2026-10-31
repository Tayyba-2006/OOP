using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Airplane_management_system.History
{
    // REPOSITORY LAYER 
    public class HistoryRepository
    {
        // READ: Load history
        public List<HistoryModel> LoadData()
        {
            List<HistoryModel> history =
                new List<HistoryModel>();

            if (File.Exists("history.txt") == false)
                return history;

            string[] lines = File.ReadAllLines("history.txt");

            foreach (string line in lines)
            {
                HistoryModel h = new HistoryModel();

                h.Action = line;

                history.Add(h);
            }

            return history;
        }

        // WRITE: Save history
        public void SaveAction(string action)
        {
            List<HistoryModel> history = LoadData();

            HistoryModel h = new HistoryModel();

            h.Action = action;

            history.Add(h);

            List<string> lines = new List<string>();

            foreach (HistoryModel item in history)
            {
                lines.Add(item.Action);
            }

            File.WriteAllLines("history.txt", lines);
        }
    }
}
