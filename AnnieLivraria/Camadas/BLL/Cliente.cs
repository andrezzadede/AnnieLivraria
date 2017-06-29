using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnieLivraria.Camadas.BLL
{
    public class Cliente
    {
        public List<Model.Cliente> Select()
        {
            DAL.Cliente dalCli = new DAL.Cliente();

            return dalCli.Select();
        }

        public void Insert(Model.Cliente cliente)
        {
            DAL.Cliente dalCli = new DAL.Cliente();

            dalCli.Insert(cliente);
        }

        public void Update (Model.Cliente cliente)
        {
            DAL.Cliente dalCli = new DAL.Cliente();
            dalCli.Update(cliente);
        }

        public void Delete(Model.Cliente cliente)
        {
            DAL.Cliente dalCli = new DAL.Cliente();
            dalCli.Delete(cliente);
        }
    }
}
