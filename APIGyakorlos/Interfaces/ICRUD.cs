using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIGyakorlos.Models;
namespace APIGyakorlos.Interfaces
{
    public interface ICRUD
    {
        List<Orszag> GetAll();

        Orszag GetById(int id);

        string Insert(Orszag orszag);

        string Update(Orszag orszag);

        string Delete(int id);
    };
}
