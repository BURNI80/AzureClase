using ApiCoreCrudDoctores.Data;
using ApiCoreCrudDoctores.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudDoctores.Repositories
{
    public class RepositoryDoctores
    {
        private ContextDoctores context;

        public RepositoryDoctores(ContextDoctores context)
        {
            this.context = context;
        }

        public async Task<List<Doctor>> GetDoctores()
        {
            return await this.context.Doctores.ToListAsync();
        }

        public async Task<Doctor> FindDoctor(int id)
        {
            return await this.context.Doctores.Where(x => x.DoctorNo == id).FirstOrDefaultAsync();
        }

        public async Task DeleteDoctor(int id)
        {
            Doctor d = await FindDoctor(id);
            context.Doctores.Remove(d);
            await context.SaveChangesAsync();
        }

        public async Task<Doctor> CreateDoctor(int numHosp, int numDoc, string apellido, string espec, int salario)
        {
            Doctor doctor = new Doctor();
            doctor.HospiCod = numHosp;
            doctor.DoctorNo = numDoc;
            doctor.Apellido = apellido;
            doctor.Especialidad = espec;
            doctor.Salario = salario;
            context.Doctores.Add(doctor);
            await context.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> UpdateDoctor(int numHosp, int numDoc, string apellido, string espec, int salario)
        {
            Doctor d = await FindDoctor(numDoc);
            d.Apellido = apellido;
            d.Especialidad = espec;
            d.Salario = salario;
            d.HospiCod = numHosp;
            await context.SaveChangesAsync();
            return d;
        }



    }
}
