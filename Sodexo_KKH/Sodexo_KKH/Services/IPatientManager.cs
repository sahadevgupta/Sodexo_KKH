using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Sodexo_KKH.Models;

namespace Sodexo_KKH.Services
{
    public interface IPatientManager
    {
        Task<ObservableCollection<mstr_patient_info>> GetPatientsByWardBed(string DateFormat, int wardID, int bedID);
    }
}