using Newtonsoft.Json;
using Sodexo_KKH.Helpers;
using Sodexo_KKH.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sodexo_KKH.Services
{
    public class PatientManager : IPatientManager
    {

        public PatientManager()
        {

        }

        public async Task<ObservableCollection<mstr_patient_info>> GetPatientsByWardBed(string DateFormat, int wardID, int bedID)
        {
            HttpClient httpClient = new System.Net.Http.HttpClient();
            string URL = Library.KEY_http + Library.KEY_SERVER_IP + "/" + Library.KEY_SERVER_LOCATION + "/sodexo.svc";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{URL}/{Library.METHOD_PULLPATIENTSBYWARD}/{Library.KEY_USER_SiteCode}/{DateFormat}/{wardID}/{bedID}");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ObservableCollection<mstr_patient_info>>(data);
        }
    }
}
