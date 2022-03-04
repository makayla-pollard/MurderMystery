using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MurderMystery.Models;

namespace MurderMystery.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<MurderSuspect> GetSuspects();
        void AddSuspect(MurderSuspect suspect);
        MurderSuspect GetSuspect(int? id);
        void DeleteSuspect(int? id);
        MurderSuspect GetRandomFromList();
        string GetClueOne(MurderSuspect suspect);
        string GetClueTwo(MurderSuspect suspect);
        string GetClueThree(MurderSuspect suspect);
        string CheckSuspect(MurderSuspect suspect, string guess);

    }
}
