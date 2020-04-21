using LookUpData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LookUpService
{
    public interface ILookUpService
    {
        Task<int> PostLookUp(LookUp newLookUp);

        Task<LookUp> GetLookUp(int id);

        Task<bool> PutLookUp(int id, LookUp updatedLookUp);

        Task<bool> DeleteLookUp(int id);

        Task<List<LookUp>> GetLookUps(int TypeId);

    }
}
