using MvcCoreApiCrudDoctores.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MvcCoreApiCrudDoctores.Services
{
    public class ServiceApiDoctores
    {

        private MediaTypeWithQualityHeaderValue Header;
        private string UrlApi;

        public ServiceApiDoctores(IConfiguration configuration)
        {
            this.Header =
                new MediaTypeWithQualityHeaderValue("application/json");
            this.UrlApi = configuration.GetValue<string>
                ("ApiUrls:ApiCrudDoctores");
        }


        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }


        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            string request = "/api/doctores";
            List<Doctor> doctores =
                await this.CallApiAsync<List<Doctor>>(request);
            return doctores;
        }

        public async Task DeleteDoctor(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/doctores/" + id;
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response =
                    await client.DeleteAsync(request);
            }
        }


        public async Task InsertDoctorAsync
            (int hospCod, int docCod, string apellido, string especialidad, int salario)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/doctores/";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                //TENEMOS QUE ENVIAR UN OBJETO JSON
                //NOS CREAMOS UN OBJETO DE LA CLASE DEPARTAMENTO
                Doctor doctor = new Doctor();
                doctor.HospiCod = hospCod;
                doctor.DoctorNo = docCod;
                doctor.Apellido = apellido;
                doctor.Especialidad = especialidad;
                doctor.Salario = salario;
                //CONVERTIMOS EL OBJETO A JSON
                string json = JsonConvert.SerializeObject(doctor);
                //PARA ENVIAR DATOS (data) AL SERVICIO SE UTILIZA
                //LA CLASE StringContent, DONDE DEBEMOS INDICAR
                //LOS DATOS, SU ENCODING Y SU TIPO
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(request, content);
            }
        }

    }
}
