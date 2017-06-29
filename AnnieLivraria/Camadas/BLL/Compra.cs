using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnieLivraria.Camadas.BLL
{
    public class Compra
    {
        public List<Model.Compra> Select()
        {
            DAL.Compra dalCom = new DAL.Compra();

            return dalCom.Select();
        }

        public void Insert(Model.Compra compra)
        {
            DAL.Compra dalCom = new DAL.Compra();

            dalCom.Insert(compra);
        }

        public void Update(Model.Compra compra)
        {
            DAL.Compra dalCom = new DAL.Compra();
            dalCom.Update(compra);
        }

        public void Delete(Model.Compra compra)
        {
            DAL.Compra dalCom = new DAL.Compra();
            dalCom.Delete(compra);
        }
    }
}
